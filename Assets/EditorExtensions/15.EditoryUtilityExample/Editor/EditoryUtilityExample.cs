using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class EditoryUtilityExample : EditorWindow
    {
        [MenuItem("EditorExtensions/11.EditoryUtility/Open")]
        static void Open()
        {
            GetWindow<EditoryUtilityExample>().Show();
        }

        private void OnGUI()
        {
            if(GUILayout.Button("Open"))
            {
                EditorUtility.DisplayProgressBar("Open", "Open", 0.5f);
            }
            
            if(GUILayout.Button("clear"))
            {
                EditorUtility.ClearProgressBar();
            }

            if (GUILayout.Button("DisplayDialog"))
            {
                Debug.Log(EditorUtility.DisplayDialog("DisplayDialog", "DisplayDialog", "ok", "cancel"));
            }
                
        }
    }
}

