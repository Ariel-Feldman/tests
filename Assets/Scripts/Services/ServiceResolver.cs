using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Services
{
    public static class ServiceResolver
    {
        private static UnityAction<Type, bool> _onServiceInit;
        
        public static async Task<bool> InitServices()
        {
            TaskCompletionSource<string> tcsOfSomeThingToWait = null;
            _onServiceInit += OnServiceAdded;
            if (!await PushNotificationService.Init(tcsOfSomeThingToWait))
                return false;
            
            DeepLinkService.Init(_onServiceInit);

            await tcsOfSomeThingToWait.Task;
            return true;
        }

        private static void OnServiceAdded(Type serviceType, bool isInitialized)
        {
            Debug.Log($"{serviceType} Initialized: {isInitialized}");
        }
    } 
}
