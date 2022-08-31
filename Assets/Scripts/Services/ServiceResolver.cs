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
            _onServiceInit += OnServiceAdded;
            if (!await PushNotificationService.Init(_onServiceInit))
                return false;
            
            DeepLinkService.Init(_onServiceInit);

            return true;
        }

        private static void OnServiceAdded(Type serviceType, bool isInitialized)
        {
            Debug.Log($"{serviceType} Initialized: {isInitialized}");
        }
    } 
}