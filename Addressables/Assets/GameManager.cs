using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class GameManager : MonoBehaviour
{
    public string address = "Assets/UnityChan/SD_unitychan/Prefabs/ToonShader_SD_unitychan_humanoid_Illust.prefab";

    AsyncOperationHandle<GameObject> op;

    IEnumerator LoadCoroutine(string address) {
        op = Addressables.LoadAssetAsync<GameObject>(address);
        yield return op;
        Instantiate(op.Result);
    }

    public void Load(){
        StartCoroutine(LoadCoroutine(address));
    }

    public void UnLoad(){
        //prefab引用的资源会被一并加载，所以用完的时候记得释放一下
        Addressables.Release(op);
    }
}
