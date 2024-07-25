using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class GameManager : MonoBehaviour
{
    public string address = "Assets/UnityChan/SD_unitychan/Prefabs/ToonShader_SD_unitychan_humanoid_Illust.prefab";

    AsyncOperationHandle<GameObject> loadHandle;

    IEnumerator LoadCoroutine(string address)
    {
        loadHandle = Addressables.LoadAssetAsync<GameObject>(address);
        yield return loadHandle;
        if (loadHandle.Status == AsyncOperationStatus.Succeeded)
            Instantiate(loadHandle.Result);
        else 
            Debug.LogError("Load Failed");
    }

    public void Load()
    {
        if(loadHandle.IsValid())
            Instantiate(loadHandle.Result);
        else
            StartCoroutine(LoadCoroutine(address));
    }

    public void Unload()
    {
        //prefab引用的资源会被一并加载，所以用完的时候记得释放一下
        if(loadHandle.IsValid())
            Addressables.Release(loadHandle);
    }
}
