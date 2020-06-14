//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using System.Collections.Generic;
using UnityEngine;

namespace Lumpn.Messaging
{
    public sealed class TestMessageReceiver : MonoBehaviour, IMessageReceiver
    {
        public readonly List<Message> received = new List<Message>();

        public void Register(Message message)
        {
            message.Register(this);
        }

        public void Deregister(Message message)
        {
            message.Deregister(this);
        }

        public void OnMessage(Message message)
        {
            received.Add(message);
        }
    }
}
