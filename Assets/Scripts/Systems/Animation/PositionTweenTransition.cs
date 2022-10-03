using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public class PositionTweenTransition : TweenTransition
    {
        [SerializeField] private Transform _endTarget;
        [SerializeField] private bool _snapping;
    
        public override void SetTween()
        {
            Tween = _transform.DOMove(_endTarget.position, _duration, _snapping)
                .SetEase(_ease).OnComplete(() => OnTransitionEnded?.Invoke());
        }
    }
}
