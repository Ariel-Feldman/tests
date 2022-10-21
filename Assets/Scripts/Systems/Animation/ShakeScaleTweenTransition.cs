using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public class ShakeScaleTweenTransition : TweenTransition
    {
        [SerializeField] private Vector3 _strength;
        [SerializeField] private int _vibrato;
        [SerializeField] private float _randomness;
        
        [SerializeField] private bool _loop;

        public override void SetTween()
        {
            Tween = _transform.DOShakeScale(_duration, _strength , _vibrato, _randomness,true ,ShakeRandomnessMode.Harmonic);
            if (_loop)
            {
                Tween.SetEase(_ease).SetLoops(-1);
            }
            else
                base.SetTween();        
        }
    }
}