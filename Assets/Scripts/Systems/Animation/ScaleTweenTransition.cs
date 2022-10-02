using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public class ScaleTweenTransition : TweenTransition
    {
        [SerializeField] private float _scaleFactor;
        
        public override void StartTransition()
        {
            Debug.Log("Start Tween");
            _tween = _transform.DOScale(_transform.localScale * _scaleFactor, _duration)
                .SetEase(_ease).OnComplete(() => OnTransitionEnded?.Invoke());
        }
    }
}
