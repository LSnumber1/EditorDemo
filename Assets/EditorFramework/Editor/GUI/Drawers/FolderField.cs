using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class FolderField : GUIBase
    {

        public FolderField(string path = "Assets", string folder = "Assets", string title = "Selct Folder",
            string defalutName = "")
        {
            mPath = path;
            Title = title;
            Folder = folder;
            DefaultName = defalutName;
        }
        
        protected string mPath;
        public string Path => mPath;
        private string Title;
        private string Folder;
        private string DefaultName;
        
        public void SetPath(string path)
        {
            mPath = path;
        }
        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            
            var rects = position.VerticalSplit(position.width - 30);
            var leftRect = rects[0];
            var rightRect = rects[1];

            var currentGUIEnabled = GUI.enabled;
            GUI.enabled = false;
            EditorGUI.TextField(leftRect,mPath);
            GUI.enabled = currentGUIEnabled;
            
            if (GUI.Button(rightRect, GUIContents.Folder))
            {
                var path = EditorUtility.OpenFolderPanel(Title, Folder, DefaultName);
               
                if(!string.IsNullOrEmpty(path) && path.IsDirectory())
                {
                    mPath = path.ToAssetsPath(); 
                } 
            } 

            var dragInfo = DragAndDropTools.Drag(Event.current, position);
            if (dragInfo.EnterArea && dragInfo.Complete && !dragInfo.Dragging && dragInfo.Paths[0].IsDirectory())
            {
                mPath = dragInfo.Paths[0];
            }
        }

        protected override void OnDispose()
        {
           
        }
    }

}
