using System;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Services
{
    public static class DeepLinkService
    {
        public static Task Init(UnityAction<Type, bool> onServiceInit)
        {
            DebugSystem.Log("Starting DL Service");
            onServiceInit.Invoke(typeof(DeepLinkService), true);
            return Task.CompletedTask;
        }
    }
}

