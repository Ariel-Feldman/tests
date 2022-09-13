using DG.Tweening;
using UnityEngine;

public class TweenTransition : MonoBehaviour
{
    [SerializeField] private TransitionType _transitionType;
    
    private void Awake()
    {
        if (_transitionType == TransitionType.TransitionIn)
        {
            transform.DOScale(transform.localScale / 2, 2f).SetLoops(-1, LoopType.Yoyo);
        }
    }
}

public enum TransitionType
{
    TransitionIn,
    Idle,
    TransitionOut  
}
