using Ariel.Utilities;

namespace Ariel.Services
{
    using UnityEngine.Events;
    
    public class MonoService : Singleton<MonoService>
    {
        public static UnityAction OnAppBackInFocus;
        public static UnityAction OnAppOutOfFocus;
        
        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus) OnAppBackInFocus?.Invoke();
            else OnAppOutOfFocus?.Invoke();
        }
    }
}
