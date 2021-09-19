//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace Lumpn.Messaging
{
    [CustomEditor(typeof(LocalMessage))]
    public class LocalMessageEditor : Editor<LocalMessage>
    {
        public override void OnInspectorGUI(LocalMessage message)
        {
            EditorGUILayout.LabelField("Receivers");
            foreach (var receiver in message.Receivers.SelectMany(p => p.Value))
            {
                if (receiver is Object obj)
                {
                    EditorGUILayout.ObjectField(obj.name, obj, typeof(Object), true);
                }
            }

            Repaint();
        }
    }
}
