using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Ariel.Systems
{
    public static class AddressableSystem
    {
        // public static async Task<bool> InitSystem()
        // {
        //     var tcs = new TaskCompletionSource<bool>();
        //     Addressables.InitializeAsync().Completed += SetTcs;
        //     void SetTcs(AsyncOperationHandle<IResourceLocator> handle)
        //     {
        //         tcs.SetResult(handle.Status == AsyncOperationStatus.Succeeded);
        //     }
        //     
        //     await tcs.Task;
        //     return tcs.Task.Result;
        // }
        
        public static async Task<bool> InitSystem()
        {
            var tcs = await Addressables.InitializeAsync().Task;
            return tcs != null;
        }
    }
}
