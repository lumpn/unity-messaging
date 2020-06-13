using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lumpn.Messaging
{
    public sealed class TestMessageReceiver : MonoBehaviour, IMessageReceiver
    {
        public readonly List<IMessage> received = new List<IMessage>();

        public void Register(Message message)
        {
            message.Register(this);
        }

        public void Deregister(Message message)
        {
            message.Deregister(this);
        }

        public void OnMessage(IMessage message)
        {
            received.Add(message);
        }
    }
}
