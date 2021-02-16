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

        private readonly Dictionary<GameObject, List<IMessageReceiver>> allReceivers = new Dictionary<GameObject, List<IMessageReceiver>>();

        internal IEnumerable<KeyValuePair<GameObject, List<IMessageReceiver>>> Receivers { get { return allReceivers; } }

        public override void Send(GameObject context)
        {
            var receivers = allReceivers.GetOrFallback(context, emptyList);
            foreach (var receiver in receivers)
            {
                receiver.OnMessage(this);
            }
        }

        public override void Register(IMessageReceiver receiver)
        {
            var receivers = allReceivers.GetOrAddNew(receiver.gameObject);
            receivers.Add(receiver);
        }

        public override void Deregister(IMessageReceiver receiver)
        {
            var receivers = allReceivers.GetOrFallback(receiver.gameObject, emptyList);
            receivers.RemoveUnordered(receiver);
        }
    }
}
