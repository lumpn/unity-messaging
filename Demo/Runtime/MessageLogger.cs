//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using UnityEngine;

namespace Lumpn.Messaging
{
    public sealed class MessageLogger : MonoBehaviour, IMessageReceiver
    {
        [SerializeField] private Message[] messages;

        public void OnMessage(Message message)
        {
            Debug.LogFormat(this, "Message '{0}' received", message.name);
        }

        void OnEnable()
        {
            foreach (var message in messages)
            {
                message.Register(this);
            }
        }

        void OnDisable()
        {
            foreach (var message in messages)
            {
                message.Deregister(this);
            }
        }
    }
}
