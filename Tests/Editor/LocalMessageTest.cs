//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using NUnit.Framework;
using UnityEngine;

namespace Lumpn.Messaging.Tests
{
    [TestFixture]
    public sealed class LocalMessageTest
    {
        [Test]
        public void TestLocalMessage()
        {
            var msg = ScriptableObject.CreateInstance<LocalMessage>();

            var go = new GameObject("Test");
            var rec = go.AddComponent<MessageReceiver>();
            msg.Register(rec);
            Assert.AreEqual(0, rec.received.Count);

            // receives message sent to same game object
            msg.Send(go);
            Assert.AreEqual(1, rec.received.Count);
            Assert.AreEqual(msg, rec.received[0]);

            // receives message again sent to same game object
            msg.Send(go);
            Assert.AreEqual(2, rec.received.Count);
            Assert.AreEqual(msg, rec.received[0]);
            Assert.AreEqual(msg, rec.received[1]);

            // does not receive message sent to another game object
            var go2 = new GameObject("Test2");
            msg.Send(go2);
            Assert.AreEqual(2, rec.received.Count);

            // does not receive another message sent to same game object
            var msg2 = ScriptableObject.CreateInstance<LocalMessage>();
            msg2.Send(go2);
            Assert.AreEqual(2, rec.received.Count);

            msg.Deregister(rec);

            Object.DestroyImmediate(msg2);
            Object.DestroyImmediate(msg);
            Object.DestroyImmediate(go2);
            Object.DestroyImmediate(go);
        }
    }
}
