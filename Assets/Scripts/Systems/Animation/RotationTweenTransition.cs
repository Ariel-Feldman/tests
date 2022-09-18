using DG.Tweening;
using UnityEngine;

namespace ArielSystems.Animations
{
    public class RotationTweenTransition : TweenTransition
    {
        [SerializeField] private Transform _endTarget;
        [SerializeField] private bool _snapping;
    
        public override void StartTransition()
        {
            _transform.DORotateQuaternion(_endTarget.rotation, _duration)
                .SetEase(_ease).OnComplete(() => OnTransitionEnded?.Invoke());
        }
    }
}
