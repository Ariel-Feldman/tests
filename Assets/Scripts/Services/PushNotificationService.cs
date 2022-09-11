using System;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Services
{
    public static class PushNotificationService
    {
        public static async Task Init(UnityAction<Type, bool> onServiceAdded)
        {
            DebugSystem.Log("Starting PN Service");
            await Task.Delay(500);
            onServiceAdded.Invoke(typeof(PushNotificationService), true);
        }
    }
}
