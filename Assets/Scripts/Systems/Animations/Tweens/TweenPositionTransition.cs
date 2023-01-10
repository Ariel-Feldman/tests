using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public class TweenPositionTransition : BaseTweenTransition
    {
        [SerializeField] private Vector3 _reletiveStartPostion;
        [SerializeField] private Vector3 _reletiveEndPosition;

        private Vector3 _positionValueOrigin;
        private Vector3 _positionEndValue;
        private Vector3 _positionEditorValue;
        
        protected override void SetTweenInstance()
        {
            _positionValueOrigin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Tween = transform.DOMove(_positionValueOrigin + _reletiveEndPosition, _duration);
        }

        protected override void SetTweenStart()
        {
            transform.localPosition = _positionValueOrigin + _reletiveStartPostion;
        }

        // Editor Preview  
        protected override void GetEditorStartValue()
        {
            _positionEditorValue = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }

        protected override void SetEditorStartValue() => transform.localPosition = _positionEditorValue;
    }

}
