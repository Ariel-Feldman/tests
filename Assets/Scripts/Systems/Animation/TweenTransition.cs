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

        public Action OnTransitionEnded;
        public abstract void StartTransition();
    }
}