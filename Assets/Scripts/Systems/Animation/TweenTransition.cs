using System;
using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public abstract class TweenTransition : MonoBehaviour
    {
        
        [SerializeField] protected Transform _transform;
        [SerializeField] protected float _duration;
        [SerializeField] protected Ease _ease;

        protected Tween _tween;
        public Action OnTransitionEnded;
        public abstract void StartTransition();
        
        [ContextMenu("Run Tween")]
        public void PlayTweenInEditMode()
        {
            // PlayTweenInEditor.RunTween(_tween);
        }
    }
}