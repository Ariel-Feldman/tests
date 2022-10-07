using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public class ScaleTweenTransition : TweenTransition
    {
        [SerializeField] private bool _scaleFromZero;
        
        public override void SetTween()
        {
            var scaleTarget = _scaleFromZero ? 1 : 0;
            Tween = _transform.DOScale(scaleTarget, _duration);
            if (_scaleFromZero)
                Tween.OnStart(() => _transform.localScale = Vector3.zero);
            
            base.SetTween();
            
            if (Application.isEditor)
                EditorPreviewFix();
        }

        private void EditorPreviewFix()
        {
            _transform.localScale = _scaleFromZero ? Vector3.zero : Vector3.one;
            Tween.OnComplete(EditorRunEnded);

            void EditorRunEnded()
            {
                OnTweenEnd();
                _transform.localScale = Vector3.one;
            }
        }
    }
}
