using System.Threading.Tasks;
using Ariel.Systems;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Ariel.Models
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private AssetReference _bootSceneAssetsReferences;

        private async Task Start()
        {

            if (!await AddressableSystem.InitSystem())
            {
                Debug.Log("Fail To Activate Addressable System, Quit");
                return;
            }

            Addressables.LoadSceneAsync(_bootSceneAssetsReferences).Completed += OnBootSceneLoaded;
        }

        private void OnBootSceneLoaded(AsyncOperationHandle<SceneInstance> handle)
        {
            if (handle.Status != AsyncOperationStatus.Succeeded)
                Debug.Log("Fail to Load BootScene");
            else
                AppBoot.Boot();
        }
    }
}
