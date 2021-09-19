//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using NUnit.Framework;
using UnityEngine;

namespace Lumpn.Messaging.Tests
{
    [TestFixture]
    public sealed class GlobalMessageTest
    {
        [Test]
        public void TestGlobalMessage()
        {
            var msg = ScriptableObject.CreateInstance<GlobalMessage>();

            var rec = new GlobalMessageReceiver();
            msg.Register(rec);
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
            var rec2 = go.AddComponent<MessageReceiver>();
            msg.Register(rec2);
            Assert.AreEqual(0, rec2.received.Count);
            msg.Send();
            Assert.AreEqual(1, rec2.received.Count);
            Assert.AreEqual(msg, rec2.received[0]);

            msg.Deregister(rec);

            Object.DestroyImmediate(msg2);
            Object.DestroyImmediate(msg);
            Object.DestroyImmediate(go);
        }
    }
}
