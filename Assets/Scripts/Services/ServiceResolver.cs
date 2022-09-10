using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Services
{
    public static class ServiceResolver
    {
        public static async Task InitServices()
        {
            var tasks = new List<Task>();
            
            tasks.Add(new Task( () => PushNotificationService.Init(OnServiceAdded)));
            tasks.Add(DeepLinkService.Init(OnServiceAdded));

            // await Task.WhenAll(tasks);
            
            var t = Task.WhenAll(tasks);

            
            //
            // if (t.Status == TaskStatus.RanToCompletion)
            //     DebugSystem.Log("All system is a go");
            // else if (t.Status == TaskStatus.Faulted)
            //     DebugSystem.Log("All system is a No go");
        }
        
        private static void OnServiceAdded(Type serviceType, bool isInitialized)
        {
            // Debug.Log($"{serviceType} Initialized: {isInitialized}");
        }
    } 
}
