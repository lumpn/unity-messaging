//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using UnityEngine;

namespace Lumpn.Messaging
{
    [CreateAssetMenu]
    public sealed class MessageCounter : ScriptableObject, IGlobalMessageReceiver
    {
        [SerializeField] private GlobalMessage message;

        [field: System.NonSerialized] public int count { get; private set; }

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
