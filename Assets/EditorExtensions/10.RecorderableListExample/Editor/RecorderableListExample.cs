using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace EditorExtensions
{
    public class RecorderableListExample : EditorWindow
    {

        [MenuItem("EditorExtensions/06.RecorderableList/Open")]
        static void Open()
        {
            GetWindow<RecorderableListExample>().Show();
        }
 
        private ReorderableList mList;
        private List<Vector2> mData = new List<Vector2>();

        private void OnEnable()
        {
            mList = new ReorderableList(mData, typeof(Vector2));
            mList.elementHeight = 30;
            mList.drawHeaderCallback += DrawHeader;
            mList.drawNoneElementCallback += DrawNoneElement;
            mList.drawElementCallback += DrawElement;
            mList.drawElementBackgroundCallback += DrawElementBg;
        }

        private void DrawElementBg(Rect rect, int index, bool isactive, bool isfocused)
        {
            GUI.DrawTexture(rect, Texture2D.whiteTexture);
        }

        private void DrawElement(Rect rect, int index, bool isactive, bool isfocused)
        {
            mData[index] = EditorGUI.Vector2Field(rect, "", mData[index]);
        }

        private void DrawNoneElement(Rect rect)
        {
            
        }

        private void DrawHeader(Rect rect)
        {
            GUI.Box(rect, "Header");
        }

        private void OnGUI()
        {
            mList.DoLayoutList();
        }
    }

}
