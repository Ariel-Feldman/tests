using System;
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
            _statesHash.Add(Animator.StringToHash(state));
        
        AnimatorStateMachine.OnAnimatorStateEnter += OnStateEnter;
        AnimatorStateMachine.OnAnimatorStateExit += OnStateExit;
    }

    private void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo)
    {
        if (animator != _animator) return;
        for (var i = 0; i < _statesHash.Count; i++)
        {
            if (_statesHash[i] == animatorStateInfo.shortNameHash)
            {
                if (i == 0)
                    OnTransitionInStarted();
                if (i == 1)
                    OnIdleStarted();
                if (i == 2)
                    OnTransitionOutStarted();
            }
        }
    }
    
    private void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo)
    {
        if (animator != _animator) return;
        for (var i = 0; i < _statesHash.Count; i++)
        {
            if (_statesHash[i] == animatorStateInfo.shortNameHash)
            {
                if (i == 0)
                    OnTransitionInEnded();
                if (i == 1)
                    OnIdleEnded();
                if (i == 2)
                    OnTransitionOutEnded();
            }
        }
    }

    public void OnTransitionInStarted()
    {
        // Debug.Log("Transition In Started");
    }
    
    public void OnTransitionInEnded()
    {
        // Debug.Log("Transition In Ended");
    }
    
    public void OnIdleStarted()
    {
        // Debug.Log("Transition Idle Started");
    }
    
    public void OnIdleEnded()
    {
        // Debug.Log("Transition In Ended");
    }
    
    public void OnTransitionOutStarted()
    {
        // Debug.Log("Transition Out Started");
    }
    
    public void OnTransitionOutEnded()
    {
        // Debug.Log("Transition Out Ended");
        _animator.enabled = false;
    }
}
