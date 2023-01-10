using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public class TweenFadeTransition : BaseTweenTransition
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _alphaEndValue;
        [SerializeField] private float _alphaStartValue;
        
        private float _alphaEditorValue;


        protected override void SetTweenInstance()
        {
            Tween = _canvasGroup.DOFade(_alphaEndValue, _duration);
        }

        protected override void SetTweenStart() => _canvasGroup.alpha = _alphaStartValue;
        
        // Editor Preview  
        protected override void GetEditorStartValue() => _alphaEditorValue = _canvasGroup.alpha;
        protected override void SetEditorStartValue() => _canvasGroup.alpha = _alphaEditorValue;
    }
}
