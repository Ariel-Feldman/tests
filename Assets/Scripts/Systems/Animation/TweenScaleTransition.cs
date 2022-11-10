using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public class TweenScaleTransition : TweenTransition
    {
        [SerializeField] private int _scaleStartValue;
        [SerializeField] private int _scaleEndValue;
        
        public override void SetTween()
        {
            Tween = _transform.DOScale(_scaleEndValue, _duration).OnStart(SetScaleStartValue);
            base.SetTween();
            if (Application.isEditor)
                EditorPreviewFix();
        }
        
        private void EditorPreviewFix()
        {
            SetScaleStartValue();
            Tween.OnComplete(EditorRunEnded);
            void EditorRunEnded()
            {
                OnTweenEnd();
                SetScaleEndValue();
            }
        }
        
        private void SetScaleStartValue() => _transform.localScale = Vector3.one * _scaleStartValue;
        private void SetScaleEndValue() => _transform.localScale = Vector3.one * _scaleStartValue;
    }
}
