//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using UnityEngine;
using UnityEngine.Events;

namespace Lumpn.Messaging
{
    public sealed class MessageReceiver : MonoBehaviour, IMessageReceiver
    {
        [System.Serializable]
        public struct MessageHandler
        {
            public Message message;
            public UnityEvent @event;
        }

        [SerializeField] private MessageHandler[] handlers;

        void OnEnable()
        {
            foreach (var handler in handlers)
            {
                handler.message.Register(this);
            }
        }

        void OnDisable()
        {
            foreach (var handler in handlers)
            {
                handler.message.Deregister(this);
            }
        }

        public void OnMessage(IMessage message)
        {
            foreach (var handler in handlers)
            {
                if (System.Object.ReferenceEquals(handler.message, message))
                {
                    handler.@event.Invoke();
                }
            }
        }
    }
}
