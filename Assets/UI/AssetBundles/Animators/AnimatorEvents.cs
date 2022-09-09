using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvents : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private List<string> _states;
    
    private List<int> _statesHash = new();
    
    private void Awake()
    {
        foreach (var state in _states)
        {
            var stateHash = Animator.StringToHash(state);
            _statesHash.Add(Animator.StringToHash(state));
            Debug.Log($"State Name: {state} State Hash: {stateHash}");
        }
        
        AnimatorStateMachine.OnAnimatorStateEnter += OnStateEnter;
        AnimatorStateMachine.OnAnimatorStateExit += OnStateExit;
    }

    public void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo)
    {
        Debug.Log($"Is my animator Animator?: {_animator == animator} State hash code enter: {animatorStateInfo.shortNameHash}");
    }
    
    public void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo)
    {
        Debug.Log($"Is my animator Animator?: {_animator == animator} State hash code exit: {animatorStateInfo.shortNameHash}");
    }

    public void OnTransitionInStarted()
    {
    }
    
    public void OnTransitionInEnded()
    {
    }
    
    public void OnTransitionOutStarted()
    {
    }
    
    public void OnTransitionOutEnded()
    {
    }
    
    
    public void OnTransitionIdleStarted()
    {
    }
    
    public void OnTransitionIdleEnded()
    {
    }
}
