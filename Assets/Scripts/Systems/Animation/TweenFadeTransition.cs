using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public class TweenFadeTransition : TweenTransition
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _alphaEndValue;
        [SerializeField] private float _alphaStartValue;
    
        public override void SetTween()
        {
            Tween = _canvasGroup.DOFade(_alphaEndValue, _duration).OnStart(SetAlphaStartValue);
            base.SetTween();        
            if (Application.isEditor)
                EditorPreviewFix();
        }

        private void EditorPreviewFix()
        {
            SetAlphaStartValue();
            Tween.OnComplete(EditorRunEnded);
            void EditorRunEnded()
            {
                OnTweenEnd();
                SetAlphaEndValue();
            }
        }

        private void SetAlphaStartValue() => _canvasGroup.alpha = _alphaStartValue;
        private void SetAlphaEndValue() => _canvasGroup.alpha = _alphaEndValue;
    }
}
