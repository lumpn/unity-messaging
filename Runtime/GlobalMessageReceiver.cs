//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using UnityEngine;
using UnityEngine.Events;

namespace Lumpn.Messaging
{
    public sealed class GlobalMessageReceiver : MonoBehaviour, IGlobalMessageReceiver
    {
        [System.Serializable]
        public struct MessageHandler
        {
            public GlobalMessage message;
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

        public void OnMessage(Message message)
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
