//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
namespace Lumpn.Messaging
{
    public interface IGlobalMessageReceiver
    {
        void OnMessage(IMessage message);
    }
}
