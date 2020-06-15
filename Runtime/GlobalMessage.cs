//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using System.Collections.Generic;
using UnityEngine;

namespace Lumpn.Messaging
{
    [CreateAssetMenu(fileName = "Message", menuName = "Data/Global Message")]
    public sealed class GlobalMessage : Message
    {
        private static readonly List<IGlobalMessageReceiver> emptyList = new List<IGlobalMessageReceiver>();

        private readonly List<IGlobalMessageReceiver> receivers = new List<IGlobalMessageReceiver>();

        internal IEnumerable<IGlobalMessageReceiver> Receivers { get { return receivers; } }

        public void Send()
        {
            foreach (var receiver in receivers)
            {
                receiver.OnMessage(this);
            }
        }

        public void Register(IGlobalMessageReceiver receiver)
        {
            receivers.Add(receiver);
        }

        public void Deregister(IGlobalMessageReceiver receiver)
        {
            receivers.RemoveUnordered(receiver);
        }

        public override void Send(GameObject context)
        {
            Send();
        }

        public override void Register(IMessageReceiver receiver)
        {
            Register((IGlobalMessageReceiver)receiver);
        }

        public override void Deregister(IMessageReceiver receiver)
        {
            Deregister((IGlobalMessageReceiver)receiver);
        }
    }
}
