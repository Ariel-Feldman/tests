using System;
using UnityEngine.Events;

namespace Services
{
    public static class ServiceResolver
    {
        public static UnityAction<bool> OnServiceInit;
        
        public static void InitServices()
        {
            OnServiceInit += OnServiceAdded;
            PushNotificationService.Init();
            DeepLinkService.Init();
            
        }

        private static void OnServiceAdded(bool isActive)
        {
            throw new NotImplementedException();
        }

    } 
}