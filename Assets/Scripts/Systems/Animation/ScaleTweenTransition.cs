using System.Threading.Tasks;
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
            base.SetTween();
            
            if (!_scaleFromZero) 
                return;
            
            Tween.OnStart(() => _transform.localScale = Vector3.zero);
            
            if (Application.isEditor)
                EditorPreviewFix();
        }

        private async void EditorPreviewFix()
        {
            _transform.localScale = Vector3.zero;
            await Task.Delay((int)(_duration * 1010));
            _transform.localScale = Vector3.one;
        }
    }
}
