using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public class TweenPositionTransition : BaseTweenTransition
    {
        [SerializeField] private Transform _startPostion;
        [SerializeField] private Transform _endPosition;
        
        private Vector3 _positionEndValue;
        private Vector3 _positionEditorValue;
        
        protected override void SetTweenInstance()
        {
            Tween = transform.DOMove(_endPosition.position, _duration);
        }

        protected override void OnTweenStart()
        {
            transform.localPosition = _startPostion.localPosition;
        }

        // Editor Preview  
        protected override void GetEditorStartValue()
        {
            _positionEditorValue = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }

        protected override void SetEditorStartValue() => transform.localPosition = _positionEditorValue;
    }

}
