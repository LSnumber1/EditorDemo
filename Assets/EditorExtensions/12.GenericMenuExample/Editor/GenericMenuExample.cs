using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class GenericMenuExample : EditorWindow
    {
        [MenuItem("EditorExtensions/08.GenericMenuExample/Open")]
        static void Open()
        {
            GetWindow<GenericMenuExample>().Show();
        }

        private void OnGUI()
        {
            var e = Event.current;
            if (null != e)
            {
                if (e.type == EventType.MouseDown && e.button == 1)
                {
                    var genericMenu = new GenericMenu();
                    genericMenu.AddItem(new GUIContent("Item 1"), false, () => { Debug.Log("Item 1"); });
                    genericMenu.AddItem(new GUIContent("Item 1/2"), false, () => { Debug.Log("Item 2"); });
                    genericMenu.AddItem(new GUIContent("Item 1/3"), false, () => { Debug.Log("Item 3"); });
                    genericMenu.AddSeparator("Item 1/");
                    genericMenu.AddItem(new GUIContent("Item 1/4"), false, () => { Debug.Log("Item 4"); });
                    genericMenu.ShowAsContext();
                }
            }
        }
    }

}
