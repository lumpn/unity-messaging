//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using UnityEngine;
using UnityEngine.Events;

namespace Lumpn.Messaging
{
    public sealed class MessageForwarder : MonoBehaviour, IMessageReceiver
    {
        [SerializeField] private Message message;
        [SerializeField] private UnityEvent @event;

        void OnEnable()
        {
            message.Register(this);
        }

        void OnDisable()
        {
            message.Deregister(this);
        }

        public void OnMessage(Message message)
        {
            @event.Invoke();
        }
    }
}
