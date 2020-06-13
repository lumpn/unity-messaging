//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.Messaging
{
    public interface IMessage
    {
        string name { get; }

        void Register(IMessageReceiver receiver);
        void Deregister(IMessageReceiver receiver);
    }
}
