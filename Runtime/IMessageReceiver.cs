//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using UnityEngine;

namespace Lumpn.Messaging
{
    public interface IMessageReceiver : IGlobalMessageReceiver
    {
        GameObject gameObject { get; }
    }
}
