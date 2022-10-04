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

        public Tween Tween { get; protected set; }
        public Action OnTransitionEnded;

        public void StartTransition()
        {
            if (Tween == null) SetTween();
            Tween.Play();
        }

        public virtual void SetTween()
        {
            if (Tween == null) return;
            Tween.SetEase(_ease).OnComplete(() => OnTransitionEnded?.Invoke());
        }

        public float Duration => _duration;
    }
}
