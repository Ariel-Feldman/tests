using System;
using System.Threading.Tasks;
using Ariel.Services;
using DG.Tweening;
using UnityEngine;

namespace Ariel.Systems.Animations
{
    public abstract class BaseTweenTransition : MonoBehaviour
    {
        public Action OnTransitionEnded;
        public Tween Tween { get; protected set; }
        
        [SerializeField] protected float _duration;
        [SerializeField] protected Ease _ease;
        [SerializeField] private float _onAwakeSecondsDelay;
        
        public Action RunInEditorEnded;
        
        public async Task StartTransition()
        {
            SetTween();
            OnTweenStart(); // Use this instead OnComplete in DOTween
            if (_onAwakeSecondsDelay > 0)
                await DelayService.Instance.WaitSeconds(_onAwakeSecondsDelay);
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
        
        // Editor Tests code //
        // MIND DoTween callbacks dont work in editor so this is the fix //
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
