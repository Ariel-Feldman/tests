using System;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public class TweenEvents : MonoBehaviour
    {
        [SerializeField] private BaseTweenTransition baseTweenTransitionIn;
        [SerializeField] private BaseTweenTransition baseTweenTransitionIdle;
        [SerializeField] private BaseTweenTransition baseTweenTransitionOut;

        public Action TransitionOutEnded;
        
        private void Start()
        {
            if (baseTweenTransitionIn != null)
            {
                baseTweenTransitionIn.StartTransition();
                baseTweenTransitionIn.OnTransitionEnded += OnTransitionInEnded;
            }
        }

        private void OnTransitionInEnded()
        {
            baseTweenTransitionIn.OnTransitionEnded -= OnTransitionInEnded;
            if (baseTweenTransitionIdle != null) baseTweenTransitionIdle.StartTransition();
        }

        public void StartTransitionOut()
        {
            if (baseTweenTransitionOut != null)
            {
                baseTweenTransitionOut.StartTransition();
                baseTweenTransitionOut.OnTransitionEnded += OnTransitionOutEnded;
            }
        }
        
        private void OnTransitionOutEnded()
        {
            baseTweenTransitionOut.OnTransitionEnded -= OnTransitionOutEnded;
            TransitionOutEnded?.Invoke();
        }
    }
}
