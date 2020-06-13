using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lumpn.Messaging
{
    public interface IMessageReceiverBase
    {
        void OnMessage(IMessage message);
    }
}
