using UnityEngine;

namespace Lumpn.Messaging
{
    public abstract class Message : ScriptableObject
    {
        public abstract void Send(GameObject context);
        public abstract void Register(IMessageReceiver receiver);
        public abstract void Deregister(IMessageReceiver receiver);
    }
}
