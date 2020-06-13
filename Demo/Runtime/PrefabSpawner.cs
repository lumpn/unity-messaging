using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lumpn.Messaging
{
    public sealed class PrefabSpawner : IMessageReceiver
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
    }
}
