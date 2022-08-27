using System;
using UnityEngine.Events;

namespace Services
{
    public static class DeepLinkService
    {
        public static void Init(UnityAction<Type, bool> onServiceInit)
        {
            onServiceInit.Invoke(typeof(DeepLinkService), true);
        }
    }
}