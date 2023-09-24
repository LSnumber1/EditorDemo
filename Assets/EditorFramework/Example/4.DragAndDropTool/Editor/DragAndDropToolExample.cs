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

            var e = Event.current;
            bool enterArea;
            bool complete;
            bool dragging;
            if (e.type == EventType.DragUpdated)
            {
                dragging = true;
                complete = false;
                enterArea = rect.Contains(e.mousePosition);
                if (enterArea)
                {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                    e.Use();
                }
            }
            else if (e.type == EventType.DragPerform)
            {
                dragging = false;
                complete = true;
                enterArea = rect.Contains(e.mousePosition);
                DragAndDrop.AcceptDrag();
                e.Use();
            }
            else if (e.type == EventType.DragExited)
            {
                dragging = false;
                complete = true;
                enterArea = rect.Contains(e.mousePosition);
                Debug.Log("DragExited");
            }
            else
            {
                dragging = false;
                complete = false;
                enterArea = rect.Contains(e.mousePosition);
            }

            complete = complete && e.type == EventType.Used;

            if (enterArea && complete && !dragging)
            {
                //拖拽完成
                foreach (var path in DragAndDrop.paths)
                {
                    Debug.Log(path);
                }

                foreach (var objectReference in DragAndDrop.objectReferences)
                {
                    Debug.Log(objectReference);
                }
            }
        }
    }
}