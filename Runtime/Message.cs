using UnityEngine;

namespace Lumpn.Messaging
{
    public abstract class Message : ScriptableObject, IMessage
    {
        public abstract void Register(IMessageReceiver receiver);
        public abstract void Deregister(IMessageReceiver receiver);
    }
}
