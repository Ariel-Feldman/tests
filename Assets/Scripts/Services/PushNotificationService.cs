using System;
using UnityEngine.Events;

namespace Services
{
    public static class PushNotificationService
    {
        public static void Init(UnityAction<Type, bool> onServiceInit)
        {
            onServiceInit.Invoke(typeof(PushNotificationService), true);
        }
    
    }
}