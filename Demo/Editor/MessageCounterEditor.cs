//----------------------------------------
// MIT License
// Copyright(c) 2020 Jonas Boetel
//----------------------------------------
using UnityEditor;
using UnityEngine;

namespace Lumpn.Messaging.Demo
{
    [CustomEditor(typeof(MessageCounter))]
    public sealed class MessageCounterEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var host = (MessageCounter)target;

            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.IntField("Messages Received", host.count);
            EditorGUILayout.EndVertical();

            Repaint();
        }
    }
}
