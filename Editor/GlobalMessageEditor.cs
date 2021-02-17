//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using UnityEditor;
using UnityEngine;

namespace Lumpn.Messaging
{
    [CustomEditor(typeof(GlobalMessage))]
    public class GlobalMessageEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var message = (GlobalMessage)target;

            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.LabelField("Receivers");
            foreach (var receiver in message.Receivers)
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
