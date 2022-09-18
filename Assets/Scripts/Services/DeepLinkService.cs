using System;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Ariel.Services
{
    public static class DeepLinkService
    {
        public static Task Init(UnityAction<Type, bool> onServiceAdded)
        {
            onServiceAdded.Invoke(typeof(DeepLinkService), true);
            return Task.CompletedTask;
        }
    }
}

