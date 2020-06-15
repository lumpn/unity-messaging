//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using UnityEngine;

namespace Lumpn.Messaging.Demo
{
    [AddComponentMenu("")]
    public sealed class PrefabSpawner : MonoBehaviour, IMessageReceiver
    {
        [SerializeField] private Message message;

        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform attachPoint;

        void OnEnable()
        {
            message.Register(this);
        }

        void OnDisable()
        {
            message.Register(this);
        }

        public void OnMessage(Message message)
        {
            Object.Instantiate<GameObject>(prefab, attachPoint);
        }
    }
}
