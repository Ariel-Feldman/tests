using System;
using UnityEngine;

public class AnimatorStateMachine : StateMachineBehaviour
{
    public static Action<Animator, AnimatorStateInfo> OnAnimatorStateEnter;
    public static Action<Animator, AnimatorStateInfo> OnAnimatorStateExit;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnAnimatorStateEnter(animator, stateInfo);

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnAnimatorStateExit(animator, stateInfo);
    }
}
