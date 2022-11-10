using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public class TweenPositionTransition : TweenTransition
    {
        [SerializeField] private Transform _endTarget;
        [SerializeField] private bool _snapping;
    
        public override void SetTween()
        {
            Tween = _transform.DOMove(_endTarget.position, _duration, _snapping);
            base.SetTween();
        }
    }
}
