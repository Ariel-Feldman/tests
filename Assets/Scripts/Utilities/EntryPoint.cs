using Ariel.Systems;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class EntryPoint : MonoBehaviour
{
    void Start()
    {
        Addressables.LoadSceneAsync("Boot").Completed += OnBootSceneLoaded;
    }

    private void OnBootSceneLoaded(AsyncOperationHandle<SceneInstance> handle)
    {
        if (handle.Status != AsyncOperationStatus.Succeeded)
            Debug.Log("Fail to Load BootScene");
        else
            AppBoot.Boot();
    }
}
