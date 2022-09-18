using System;
using UnityEngine;
using UnityEngine.Events;

namespace ArielSystems.Animations
{
    public class TweenEvents : MonoBehaviour
    {
        [SerializeField] private TweenTransition _tweenTransitionIn;
        [SerializeField] private TweenTransition _tweenTransitionIdle;
        [SerializeField] private TweenTransition _tweenTransitionOut;

        public Action TransitionOutEnded;
        
        private void Awake()
        {
            if (_tweenTransitionIn != null)
            {
                _tweenTransitionIn.StartTransition();
                _tweenTransitionIn.OnTransitionEnded += OnTransitionInEnded;
            }
        }

        private void OnTransitionInEnded()
        {
            _tweenTransitionIn.OnTransitionEnded -= OnTransitionInEnded;
            if (_tweenTransitionIdle != null) _tweenTransitionIdle.StartTransition();
        }

        public void StartTransitionOut()
        {
            if (_tweenTransitionOut != null)
            {
                _tweenTransitionOut.StartTransition();
                _tweenTransitionOut.OnTransitionEnded += OnTransitionOutEnded;
            }
        }
        
        private void OnTransitionOutEnded()
        {
            _tweenTransitionOut.OnTransitionEnded -= OnTransitionOutEnded;
            TransitionOutEnded?.Invoke();
        }
    }
}
