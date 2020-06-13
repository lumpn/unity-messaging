using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lumpn.Messaging
{
    public sealed class PrefabSpawner : MonoBehaviour, IMessageReceiver
    {
        [SerializeField] private Message message;

        void OnEnable()
        {
            message.Register(this);
        }

        void OnDisable()
        {
            message.Register(this);
        }

        public void OnMessage(IMessage message)
        {
            throw new System.NotImplementedException();
        }
    }
}
