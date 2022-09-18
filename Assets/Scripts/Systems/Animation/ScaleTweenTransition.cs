using DG.Tweening;
using UnityEngine;

namespace Systems.Animation
{
    public class ScaleTweenTransition : TweenTransition
    {
        [SerializeField] private float _scaleFactor;
        
        public override void StartTransition()
        {
            _transform.DOScale(_transform.localScale * _scaleFactor, _duration)
                .SetEase(_ease).OnComplete(() => OnTransitionEnded?.Invoke());
        }
    }
}
