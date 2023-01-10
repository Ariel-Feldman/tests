using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public class TweenScaleTransition : BaseTweenTransition
    {
        [SerializeField] private int _scaleStartValue;
        [SerializeField] private int _scaleEndValue;
        
        private Vector3 _scaleEditorValue;
        
        protected override void SetTweenInstance()
        {
            Tween = transform.DOScale(_scaleEndValue, _duration);
        }

        protected override void SetTweenStart()
        {
            transform.localScale = Vector3.one * _scaleStartValue;
        }
        
        protected override void GetEditorStartValue()
        {
            var localScale = transform.localScale;
            _scaleEditorValue = new Vector3(localScale.x, localScale.y);
        }

        protected override void SetEditorStartValue() => transform.localScale = _scaleEditorValue;
    }
}
