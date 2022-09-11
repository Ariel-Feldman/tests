using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public static class ServiceResolver
    {
        public static async Task<bool> InitServices()
        {
            var tasks = new List<Task>();

            tasks.Add(new Task(() => PushNotificationService.Init(OnServiceAdded)));
            tasks.Add(DeepLinkService.Init(OnServiceAdded));
            tasks.Add(AnalyticsService.Init(OnServiceAdded));

            await Task.WhenAll(tasks);

            return true;

            // var t = Task.WhenAll(tasks);
            //
            // if (t.Status == TaskStatus.RanToCompletion)
            //     DebugSystem.Log("All system is a go");
            // else if (t.Status == TaskStatus.Faulted)
            //     DebugSystem.Log("All system is a No go");
        }

        private static void OnServiceAdded(Type serviceType, bool isInitialized)
        {
            DebugSystem.Log($"{serviceType} Initialized: {isInitialized}");
        }
    }
}

