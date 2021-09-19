//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using System.Collections.Generic;
using UnityEngine;

namespace Lumpn.Messaging.Tests
{
    public sealed class MessageReceiver : MonoBehaviour, IMessageReceiver
    {
        public readonly List<Message> received = new List<Message>();

        public void OnMessage(Message message)
        {
            received.Add(message);
        }
    }
}
