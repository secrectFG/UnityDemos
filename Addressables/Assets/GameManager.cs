using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;


public class GameManager : MonoBehaviour
{
    public string address = "Assets/UnityChan/SD_unitychan/Prefabs/ToonShader_SD_unitychan_humanoid_Illust.prefab";

    // private IEnumerator Start() {
    //     var op = Addressables.LoadAssetAsync<GameObject>(address);
    //     yield return op;
    //     Instantiate(op.Result);
    // }

    IEnumerator LoadCoroutine(string address) {
        var op = Addressables.LoadAssetAsync<GameObject>(address);
        yield return op;
        Instantiate(op.Result);
    }

    public void Load(){
        StartCoroutine(LoadCoroutine(address));
    }
}
