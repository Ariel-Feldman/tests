using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Ariel.Services
{
    public static class ServiceResolver
    {
        public static async Task<bool> InitServices()
        {
            var tasks = new List<Task>();
            tasks.Add(PushNotificationService.Init(OnServiceAdded));
            tasks.Add(DeepLinkService.Init(OnServiceAdded));
            tasks.Add(AnalyticsService.Init(OnServiceAdded));
            try
            {

                await Task.WhenAll(tasks);
            }
            catch (Exception e)
            {
                Debug.Log($"Fail init services e: {e}");
                return false;;
            }
            
            return true;
        }   
    

        private static void OnServiceAdded(Type serviceType, bool isInitialized)
        {
            Debug.Log($"{serviceType} Initialized: {isInitialized}");
        }
    }
}
