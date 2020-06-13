//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using UnityEngine;

namespace Lumpn.Messaging
{
    public sealed class MessageCounter : ScriptableObject, IGlobalMessageReceiver
    {
        [SerializeField] private GlobalMessage message;

        [field: System.NonSerialized] public int count { get; private set; }

        public void OnMessage(IMessage message1)
        {
            if (message1 == message)
            {
                count++;
            }
        }

        void OnEnable()
        {
            message.Register(this);
        }

        void OnDisable()
        {
            message.Deregister(this);
        }
    }
}
