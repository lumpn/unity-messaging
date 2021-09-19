//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using System.Collections.Generic;
using UnityEngine;

namespace Lumpn.Messaging
{
    [CreateAssetMenu(fileName = "Message", menuName = "Data/Message")]
    public sealed class LocalMessage : Message
    {
        private static readonly List<IMessageReceiver> emptyList = new List<IMessageReceiver>();

        private readonly Dictionary<GameObject, List<IMessageReceiver>> receivers = new Dictionary<GameObject, List<IMessageReceiver>>();

        internal IReadOnlyDictionary<GameObject, List<IMessageReceiver>> Receivers { get { return receivers; } }

        public override void Send(GameObject context)
        {
            var localReceivers = receivers.GetOrDefault(context, emptyList);
            foreach (var receiver in localReceivers)
            {
                receiver.OnMessage(this);
            }
        }

        public override void Register(IMessageReceiver receiver)
        {
            var localReceivers = receivers.GetOrAddNew(receiver.gameObject);
            localReceivers.Add(receiver);
        }

        public override void Deregister(IMessageReceiver receiver)
        {
            var localReceivers = receivers.GetOrDefault(receiver.gameObject, emptyList);
            localReceivers.RemoveUnordered(receiver);
        }
    }
}
