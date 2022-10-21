using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public class RotationTweenTransition : TweenTransition
    {
        [SerializeField] private Vector3 _endVector;
        [SerializeField] private RotateMode _rotateMode;
    
        public override void SetTween()
        {
            Tween = _transform.DORotate(_endVector, _duration, _rotateMode);
            base.SetTween();        
        }
    }
}
