using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(5)]
    public class FolderFieldExample : EditorWindow
    {
        private string mPath = "Assets";
        private FolderField mFolderField;

        private void OnEnable()
        {
            mFolderField = new FolderField();
        }

        private void OnGUI()
        {
            GUILayout.Label("FolderFieldExample");
            var rect = EditorGUILayout.GetControlRect(GUILayout.Height(20));
            mFolderField.OnGUI(rect);
          
        }
    }
  
}
