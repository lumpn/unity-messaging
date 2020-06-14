using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Lumpn.Messaging
{
    [TestFixture]
    public sealed class GlobalMessageTest
    {
        private sealed class Receiver : IGlobalMessageReceiver
        {
            public readonly List<Message> received = new List<Message>();

            public void Register(GlobalMessage message)
            {
                message.Register(this);
            }

            public void Deregister(GlobalMessage message)
            {
                message.Deregister(this);
            }

            public void OnMessage(Message message)
            {
                received.Add(message);
            }
        }

        [Test]
        public void TestGlobalMessage()
        {
            var msg = ScriptableObject.CreateInstance<GlobalMessage>();

            var rec = new Receiver();
            rec.Register(msg);
            Assert.AreEqual(0, rec.received.Count);

            // receives message sent
            msg.Send();
            Assert.AreEqual(1, rec.received.Count);
            Assert.AreEqual(msg, rec.received[0]);

            // receives message again
            msg.Send();
            Assert.AreEqual(2, rec.received.Count);
            Assert.AreEqual(msg, rec.received[0]);
            Assert.AreEqual(msg, rec.received[1]);

            // receives message sent to any game object
            var go = new GameObject("Test");
            msg.Send(go);
            Assert.AreEqual(3, rec.received.Count);
            Assert.AreEqual(msg, rec.received[0]);
            Assert.AreEqual(msg, rec.received[1]);
            Assert.AreEqual(msg, rec.received[2]);

            // does not receive another message
            var msg2 = ScriptableObject.CreateInstance<GlobalMessage>();
            msg2.Send();
            Assert.AreEqual(3, rec.received.Count);

            // local receivers also receive global messages
            var rec2 = go.AddComponent<TestMessageReceiver>();
            rec2.Register(msg);
            Assert.AreEqual(0, rec2.received.Count);
            msg.Send();
            Assert.AreEqual(1, rec2.received.Count);
            Assert.AreEqual(msg, rec2.received[0]);

            rec.Deregister(msg);

            Object.DestroyImmediate(msg2);
            Object.DestroyImmediate(msg);
            Object.DestroyImmediate(go);
        }
    }
}
