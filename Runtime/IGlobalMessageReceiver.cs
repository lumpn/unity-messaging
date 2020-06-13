namespace Lumpn.Messaging
{
    public interface IGlobalMessageReceiver
    {
        void OnMessage(Message message);
    }
}
