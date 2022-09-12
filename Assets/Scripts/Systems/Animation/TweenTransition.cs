using UnityEngine;

public class TweenTransition : MonoBehaviour
{
    [SerializeField] private TransitionType _transitionType;
    
    private void Awake()
    {
        if (_transitionType == TransitionType.TransitionIn)
        {
            
        }
    }
}

public enum TransitionType
{
    TransitionIn,
    Idle,
    TransitionOut  
}
