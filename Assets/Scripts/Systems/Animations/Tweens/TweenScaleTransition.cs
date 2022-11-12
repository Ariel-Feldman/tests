using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public class TweenScaleTransition : TweenTransition
    {
        [SerializeField] private int _scaleStartValue;
        [SerializeField] private int _scaleEndValue;
        
        private Vector3 _scaleEditorValue;
        
        
        protected override void SetTweenInstance()
        {
            Tween = _transform.DOScale(_scaleEndValue, _duration);
        }

        protected override void OnTweenStart() => _transform.localScale = Vector3.one * _scaleStartValue;
        
        protected override void GetEditorStartValue()
        {
            _scaleEditorValue = new Vector3(transform.localScale.x, transform.localScale.y);
        }

        protected override void SetEditorStartValue() => _transform.localScale = _scaleEditorValue;
    }
}
