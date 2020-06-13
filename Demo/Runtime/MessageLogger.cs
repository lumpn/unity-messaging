using UnityEngine;

namespace Lumpn.Messaging
{
    public sealed class MessageLogger : MonoBehaviour, IMessageReceiver
    {
        [SerializeField] private GlobalMessage globalMessage;
        [SerializeField] private Message message;

        public void OnMessage(Message message)
        {
        }

        void OnEnable()
        {
            globalMessage.Register(this);
            message.Register(this);
        }

        void OnDisable()
        {
            message.Deregister(this);
            globalMessage.Deregister(this);
        }
    }
}