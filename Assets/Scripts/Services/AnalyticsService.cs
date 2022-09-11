using System;
using System.Threading.Tasks;

namespace Services
{

    public static class AnalyticsService
    {
        public static async Task Init(Action<Type, bool> onServiceAdded)
        {
            DebugSystem.Log("Starting PN Service");
            await Task.Delay(500);
            onServiceAdded.Invoke(typeof(PushNotificationService), true);
        }
    }
}