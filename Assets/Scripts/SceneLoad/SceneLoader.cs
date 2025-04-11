using System;
using System.Collections;

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoSingleton<SceneLoader>
{
    public SceneData currentScene;
    public AssetReference sceneRefer;

    public IEnumerator LoadNewScene(int index)
    {
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene(index);
    }

 
    public IEnumerable UnLoadScene() 
    {
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }

 

}




