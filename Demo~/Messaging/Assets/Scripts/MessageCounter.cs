//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using UnityEngine;

namespace Lumpn.Messaging.Demo
{
    public sealed class MessageCounter : ScriptableObject, IMessageReceiver
    {
        [SerializeField] private GlobalMessage message;

        [field: System.NonSerialized] public int count { get; private set; }

        public GameObject gameObject { get { return null; } }

        public void OnMessage(Message message)
        {
            count++;
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
