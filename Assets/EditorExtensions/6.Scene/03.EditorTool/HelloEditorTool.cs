using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace EditorExtensions
{
    [EditorTool("Hello Editor Tool")]
    public class HelloEditorTool : EditorTool
    {
        public override void OnToolGUI(EditorWindow window)
        {
            // base.OnToolGUI(window);
            window.ShowNotification(new GUIContent("Hello Editor Tool"));
            
            Handles.BeginGUI();
            if (GUILayout.Button("Hello"))
            {
                Debug.Log("Hello");
            }
            Handles.EndGUI();
        }
    }
}

