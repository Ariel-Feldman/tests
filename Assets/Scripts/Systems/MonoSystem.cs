using System.Threading.Tasks;
using Ariel.Utilities;

namespace Ariel.Systems
{
    using System.Collections;
    using UnityEngine.Events;
    using System;
    
    public class MonoSystem : Singleton<MonoSystem>
    {
        public static UnityAction OnAppBackInFocus;
        public static UnityAction OnAppOutOfFocus;

        
        public async Task AwaitFrames(int numberOfFrames)
        {
            var tcs = new TaskCompletionSource<bool>(); 
            AwaitFramesEvent(numberOfFrames, () => tcs.SetResult(true));
            await tcs.Task;
        }

        private void AwaitFramesEvent(int numberOfFrames, Action onEnd)
        {
            StartCoroutine(AwaitFramesCoroutine(numberOfFrames, onEnd));
        }

        private IEnumerator AwaitFramesCoroutine(int numberOfFrames, Action onEnd)
        {
            for (int i = 0; i < numberOfFrames; i++)
                yield return null;
            
            onEnd?.Invoke();
        }
        
        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus) OnAppBackInFocus?.Invoke();
            else OnAppOutOfFocus?.Invoke();
        }
    }
}
