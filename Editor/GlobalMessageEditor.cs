//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using UnityEditor;
using UnityEngine;

namespace Lumpn.Messaging
{
    [CustomEditor(typeof(GlobalMessage))]
    public class GlobalMessageEditor : Editor<GlobalMessage>
    {
        public override void OnInspectorGUI(GlobalMessage message)
        {
            EditorGUILayout.LabelField("Receivers");
            foreach (var receiver in message.Receivers)
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
