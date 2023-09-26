using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EditorFramework;
using UnityEditor;

namespace EditorFramework
{
    [CustomEditorWindow(4)]
    public class DragAndDropToolExample : EditorWindow
    {
        private void OnGUI()
        {
            var rect = new Rect(10, 10, 300, 300);
            GUI.Box(rect, "DragAndDropToolExample");

         var info = DragAndDropTools.Drag(Event.current, rect);

            if (info.EnterArea && info.Complete && !info.Dragging)
            {
                //拖拽完成
                foreach (var path in info.Paths)
                {
                    Debug.Log(path);
                }

                foreach (var objectReference in info.ObjectReferences)
                {
                    Debug.Log(objectReference);
                }
            }
        }
    }
}