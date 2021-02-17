//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using UnityEngine;

namespace Lumpn.Messaging
{
    public static class MessagingExtensions
    {
        public static void SendMessage(this GameObject gameObject, Message message)
        {
            message.Send(gameObject);
        }

        public static void SendMessage(this Component component, Message message)
        {
            message.Send(component.gameObject);
        }
    }
}
