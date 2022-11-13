using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public class TweenPositionTransition : TweenTransition
    {
        [SerializeField] private Transform _startPostion;
        [SerializeField] private Transform _endPosition;
        
        private Vector3 _positionEndValue;
        private Vector3 _positionEditorValue;
        
        protected override void SetTweenInstance()
        {
            Tween = _transform.DOMove(_endPosition.position, _duration);
        }

        protected override void OnTweenStart()
        {
            _transform.localPosition = _startPostion.localPosition;
        }

        // Editor Preview  
        protected override void GetEditorStartValue()
        {
            _positionEditorValue = new Vector3(_transform.localPosition.x, _transform.localPosition.y, _transform.localPosition.z);
        }

        protected override void SetEditorStartValue() => _transform.localPosition = _positionEditorValue;
    }

}
