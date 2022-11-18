using UnityEngine;

namespace Ariel.Services
{
    public static class DeviceService
    {
        public static bool IsIOS() => (Application.platform == RuntimePlatform.IPhonePlayer);
        
    }
}