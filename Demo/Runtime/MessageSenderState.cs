//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using UnityEngine;

namespace Lumpn.Messaging.Demo
{
    [AddComponentMenu("")]
    public sealed class MessageSenderState : StateMachineBehaviour
    {
        [SerializeField] private Message onEnter;
        [SerializeField] private Message onExit;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!onEnter) return;
            onEnter.Send(animator.gameObject);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!onExit) return;
            onExit.Send(animator.gameObject);
        }
    }
}
