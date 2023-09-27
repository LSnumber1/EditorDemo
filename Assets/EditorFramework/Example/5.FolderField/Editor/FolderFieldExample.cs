using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(5)]
    public class FolderFieldExample : EditorWindow
    {
        private string mPath = String.Empty;
        private void OnGUI()
        {
            var rect = EditorGUILayout.GetControlRect(GUILayout.Height(20));

            var rects = rect.VerticalSplit(rect.width - 30);
            var leftRect = rects[0];
            var rightRect = rects[1];
            
            GUI.Label(leftRect,mPath);
            if (GUI.Button(rightRect, GUIContents.Folder))
            {
               var path = EditorUtility.OpenFolderPanel("打开文件", Application.dataPath, "defaultName");
               mPath = path;
               Debug.Log(path);
            } 

            var dragInfo = DragAndDropTools.Drag(Event.current, rect);
            if (dragInfo.EnterArea && dragInfo.Complete && !dragInfo.Dragging)
            {
                mPath = dragInfo.Paths[0];
            }
        }
    }
  
}
