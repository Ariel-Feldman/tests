using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public class TweenShakeScaleTransition : BaseTweenTransition
    {
        [SerializeField] private Vector3 _strength;
        [SerializeField] private int _vibrato;
        [SerializeField] private float _randomness;
        
        [SerializeField] private bool _loop;

        protected override void SetTweenInstance()
        {
            Tween = _transform.DOShakeScale(_duration, _strength , _vibrato, _randomness,true ,ShakeRandomnessMode.Harmonic);
            if (_loop)
                Tween.SetLoops(-1);
        }
    }
}