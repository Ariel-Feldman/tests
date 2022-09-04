using UnityEngine;

public class AnimatorEvents : MonoBehaviour
{
    
    
    private void Awake()
    {
        AnimatorStateMachine.OnAnimatorStateEnter += OnStateEnter;
        AnimatorStateMachine.OnAnimatorStateExit += OnStateExit;
    }

    public void OnStateEnter(AnimatorStateInfo animatorStateInfo)
    {
        Debug.Log($"qqq Animator state hash code enter: {animatorStateInfo}");
        Debug.Log($"qqq Animator state name is SomeState?: {animatorStateInfo.IsName("SomeState")}");
        
    }
    
    public void OnStateExit(AnimatorStateInfo animatorStateInfo)
    {
        Debug.Log($"qqq Animator state hash code exit: {animatorStateInfo}");
    }
}
