using System;
using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public abstract class BaseTweenTransition : MonoBehaviour
    {
        public Action OnTransitionEnded;
        public Tween Tween { get; protected set; }
        
        [SerializeField] protected Transform _transform;
        [SerializeField] protected float _duration;
        [SerializeField] protected Ease _ease;
        
        public Action RunInEditorEnded;
        
        public void StartTransition()
        {
            SetTween();
            OnTweenStart(); // use this instead OnComplete in DOTween
            Tween.Play();
        }
        
        protected abstract void SetTweenInstance();
        protected virtual void OnTweenStart() {}

        private void SetTween()
        {
            SetTweenInstance();
            Tween.SetEase(_ease);
            Tween.OnComplete(() => OnTransitionEnded?.Invoke());
        }
        
        // Editor Test code
        // MIND DoTween callbacks dont work in editor so this is the fix
        // And only on tween end
        public void SetEditorPreviewTween()
        {
            SetTween();
            GetEditorStartValue();
            OnTweenStart();

            Tween.OnComplete(EditorRunEnded);
            void EditorRunEnded()
            {
                // if tween have start value no need for this
                RunInEditorEnded.Invoke();
                SetEditorStartValue();
            }
        }
        
        protected virtual void GetEditorStartValue() {}
        protected virtual void SetEditorStartValue() {}
    }
}
