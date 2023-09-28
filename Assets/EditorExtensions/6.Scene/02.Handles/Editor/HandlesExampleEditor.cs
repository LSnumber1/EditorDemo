using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    [CustomEditor(typeof(HandlerExample))]
    public class HandlesExampleEditor : Editor
    {
        private void OnSceneGUI()
        {
            var t = target as HandlerExample;
            Handles.color = new Color(1, 0.8f, 0.4f, 1);
            Handles.DrawWireDisc(t.transform.position, t.transform.up, t.Radius);
            Handles.Label(t.transform.position, t.Radius.ToString("F1"));
            
            Handles.BeginGUI();

            if (GUILayout.Button("Hello"))
            {
                Debug.Log("Hello");
            }
            
            Handles.EndGUI();
        }
    }

}
