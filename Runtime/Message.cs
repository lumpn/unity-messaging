//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using System.Collections.Generic;
using UnityEngine;

namespace Lumpn.Messaging
{
    [CreateAssetMenu(fileName = "Message", menuName = "Data/Message")]
    public sealed class Message : ScriptableObject, IMessage
    {
        private static readonly List<IMessageReceiver> emptyList = new List<IMessageReceiver>();

        private readonly Dictionary<GameObject, List<IMessageReceiver>> allReceivers = new Dictionary<GameObject, List<IMessageReceiver>>();

        public void Send(GameObject gameObject)
        {
            var receivers = allReceivers.GetOrFallback(gameObject, emptyList);
            foreach (var receiver in receivers)
            {
                receiver.OnMessage(this);
            }
        }

        public void Register(IMessageReceiver receiver)
        {
            var receivers = allReceivers.GetOrAddNew(receiver.gameObject);
            receivers.Add(receiver);
        }

        public void Deregister(IMessageReceiver receiver)
        {
            var receivers = allReceivers.GetOrFallback(receiver.gameObject, emptyList);
            receivers.RemoveUnordered(receiver);
        }
    }
}
