using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Ariel.Utilities;
using UnityEngine.Events;

namespace Ariel.Systems
{
    public class MonoSystem : Singleton<MonoSystem>
    {
        public static UnityAction OnAppBackInFocus;
        public static UnityAction OnAppOutOfFocus;
        
        public async Task WaitFrames(int frames)
        {
            var tcs = new TaskCompletionSource<bool>(); 
            AwaitFramesEvent(frames, () => tcs.SetResult(true));
            await tcs.Task;
        }
        
        public async Task WaitSeconds(float seconds)
        {
            var tcs = new TaskCompletionSource<bool>(); 
            AwaitSecondsEvent(seconds, () => tcs.SetResult(true));
            await tcs.Task;
        }
        
        private void AwaitFramesEvent(int frames, Action onEnd)
        {
            StartCoroutine(AwaitFramesCoroutine(frames, onEnd));
        }
        
        private void AwaitSecondsEvent(float seconds, Action onEnd)
        {
            StartCoroutine(AwaitSecondsCoroutine(seconds, onEnd));
        }

        private IEnumerator AwaitFramesCoroutine(int frames, Action onEnd)
        {
            for (int i = 0; i < frames; i++)
                yield return null;
            
            onEnd?.Invoke();
        }
        
        private IEnumerator AwaitSecondsCoroutine(float seconds, Action onEnd)
        {
            float timeElapsed = 0f;
            while (Time.deltaTime + timeElapsed < seconds)
            {
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            onEnd?.Invoke();
        }
        
        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus) OnAppBackInFocus?.Invoke();
            else OnAppOutOfFocus?.Invoke();
        }
    }
}
