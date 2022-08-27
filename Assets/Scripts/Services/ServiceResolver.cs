using System;
using UnityEngine;
using UnityEngine.Events;

namespace Services
{
    public static class ServiceResolver
    {
        private static UnityAction<Type, bool> _onServiceInit;
        
        public static void InitServices()
        {
            _onServiceInit += OnServiceAdded;
            PushNotificationService.Init(_onServiceInit);
            DeepLinkService.Init(_onServiceInit);
        }

        private static void OnServiceAdded(Type serviceType, bool isInitialized)
        {
            Debug.Log($"{serviceType} Initialized: {isInitialized}");
        }
    } 
}