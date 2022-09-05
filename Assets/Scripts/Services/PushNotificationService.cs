using System;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Services
{
    public static class PushNotificationService
    {
        public static async Task<bool> Init(UnityAction<Type, bool> onServiceInit)
        {
            
            await Task.Delay(500);
            onServiceInit.Invoke(typeof(PushNotificationService), true);

            return true;
        }

        public static async Task<bool> Init(TaskCompletionSource<string> tcsOfSomeThing)
        {
            tcsOfSomeThing.SetResult("PNService");
            return true;
        }
    }
}
