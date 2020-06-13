//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using UnityEngine;

namespace Lumpn.Messaging
{
    public sealed class MessageLogger : MonoBehaviour, IMessageReceiver
    {
        [SerializeField] private GlobalMessage globalMessage;
        [SerializeField] private Message message;

        public void OnMessage(IMessage message)
        {
            Debug.LogFormat(this, "Global message '{0}' received", message.name);
        }

        void OnEnable()
        {
            globalMessage.Register(this);
            message.Register(this);
        }

        void OnDisable()
        {
            message.Deregister(this);
            globalMessage.Deregister(this);
        }
    }
}