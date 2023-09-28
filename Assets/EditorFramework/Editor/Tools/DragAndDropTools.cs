using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class DragAndDropTools 
    {
        public class DragInfo
        {
            public bool Dragging;
            public bool Complete;
            public bool EnterArea;

            public Object[] ObjectReferences => DragAndDrop.objectReferences;
            public string[] Paths => DragAndDrop.paths;
            public DragAndDropVisualMode VisualMode => DragAndDrop.visualMode;
            public int ActiveControlID => DragAndDrop.activeControlID;
        }

        private static DragInfo mDragInfo = new DragInfo();
        private static bool mDragging;
        private static bool mComplete;
        private static bool mEnterArea;
        public static DragInfo Drag(Event e, Rect content, DragAndDropVisualMode mode = DragAndDropVisualMode.Generic)
        {
          
            if (e.type == EventType.DragUpdated)
            {
                mDragging = true;
                mComplete = false;
                mEnterArea = content.Contains(e.mousePosition);
                if (mEnterArea)
                {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                    e.Use();
                }
            }
            else if (e.type == EventType.DragPerform)
            {
                mDragging = false;
                mComplete = true;
                mEnterArea = content.Contains(e.mousePosition);
                DragAndDrop.AcceptDrag();
                e.Use();
            }
            else if (e.type == EventType.DragExited)
            {
                mDragging = false;
                mComplete = true;
                mEnterArea = content.Contains(e.mousePosition);
                Debug.Log("DragExited");
            }
            else
            {
                mDragging = false; 
                mComplete = false;
                mEnterArea = content.Contains(e.mousePosition);
            }

            mDragInfo.Complete = mComplete && e.type == EventType.Used;
            mDragInfo.EnterArea = mEnterArea;
            mDragInfo.Dragging = mDragging;
            
            return mDragInfo;
        }
    }
}
