//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using System.Collections.Generic;

namespace Lumpn.Messaging.Tests
{
    public sealed class GlobalMessageReceiver : IGlobalMessageReceiver
    {
        public readonly List<Message> received = new List<Message>();

        public void OnMessage(Message message)
        {
            received.Add(message);
        }
    }
}
