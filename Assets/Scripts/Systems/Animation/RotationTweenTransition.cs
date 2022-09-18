using DG.Tweening;
using UnityEngine;

namespace Systems.Animation
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
