using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public class TweenPositionTransition : BaseTweenTransition
    {
        [SerializeField] private Transform _startPostion;

        private Vector3 _positionValueOrigin;
        private Vector3 _positionEndValue;
        private Vector3 _positionEditorValue;
        
        
        protected override void SetTweenInstance()
        {
            Tween = transform.DOLocalMove(_positionEndValue, _duration, true);
        }

        protected override void SetTweenStart()
        {
            _positionEndValue = transform.localPosition;
            transform.localPosition = _startPostion.localPosition;
        }

        // Editor Preview  
        protected override void GetEditorStartValue()
        {
            _positionEditorValue = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }

        protected override void SetEditorStartValue()
        {
            transform.localPosition = _positionEditorValue;
        }
    }

}
