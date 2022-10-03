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

        public abstract void SetTween();

        public float Duration => _duration;
    }
}
