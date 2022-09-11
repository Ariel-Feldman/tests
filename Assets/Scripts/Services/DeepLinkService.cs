using System;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Services
{
    public static class DeepLinkService
    {
        public static Task Init(UnityAction<Type, bool> onServiceAdded)
        {
            DebugSystem.Log("Starting DL Service");
            onServiceAdded.Invoke(typeof(DeepLinkService), true);
            return Task.CompletedTask;
        }
    }
}

