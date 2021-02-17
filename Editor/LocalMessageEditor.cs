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
    public class LocalMessageEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var message = (LocalMessage)target;

            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.LabelField("Receivers");
            foreach (var receiver in message.Receivers.SelectMany(p => p.Value))
            {
                var obj = receiver as Object;
                if (!obj) continue;
                EditorGUILayout.ObjectField(obj.name, obj, typeof(Object), true);
            }
            EditorGUILayout.EndVertical();

            Repaint();
        }
    }
}
