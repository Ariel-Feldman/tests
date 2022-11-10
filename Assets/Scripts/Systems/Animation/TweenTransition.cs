using System;
using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public abstract class TweenTransition : MonoBehaviour
    {
        public Action OnTransitionEnded;
        public Tween Tween { get; protected set; }
        
        [SerializeField] protected Transform _transform;
        [SerializeField] protected float _duration;
        [SerializeField] protected Ease _ease;
        
        public Action RunInEditorEnded;
        
        public void StartTransition()
        {
            SetTween();
            Tween.Play();
        }

        public virtual void SetTween()
        {
            Tween?.SetEase(_ease).OnComplete(OnTweenEnd);
        }

        protected void OnTweenEnd()
        {
            if (Application.isEditor) 
                RunInEditorEnded?.Invoke();
            else
                OnTransitionEnded?.Invoke();
        }
    }
}
