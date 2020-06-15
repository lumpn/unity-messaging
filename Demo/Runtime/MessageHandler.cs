//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using UnityEngine;
using UnityEngine.Events;

namespace Lumpn.Messaging.Demo
{
    [AddComponentMenu("")]
    public sealed class MessageHandler : MonoBehaviour, IMessageReceiver
    {
        [System.Serializable]
        public struct Handler
        {
            public Message message;
            public UnityEvent @event;
        }

        [SerializeField] private Handler[] handlers;

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

        public void OnMessage(Message message)
        {
            foreach (var handler in handlers)
            {
                if (handler.message == message)
                {
                    handler.@event.Invoke();
                }
            }
        }
    }
}
