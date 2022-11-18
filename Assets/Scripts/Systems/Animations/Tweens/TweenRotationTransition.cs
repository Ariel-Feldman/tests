using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public class TweenRotationTransition : BaseTweenTransition
    {
        [SerializeField] private Vector3 _endVector;
        [SerializeField] private RotateMode _rotateMode;
    
        protected override void SetTweenInstance()
        {
            Tween = _transform.DORotate(_endVector, _duration, _rotateMode);
        }
    }
}
