using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(6)]
    public class SpliteViewExample : EditorWindow
    {
        private SplitView mSplitView;

        private void OnEnable()
        {
            mSplitView = new SplitView();
        }

        private void OnGUI()
        {
            mSplitView.OnGUI(this.LocalPosition().Zoom(AnchorType.MiddleCenter, -10));
            mSplitView.FirstArea += MSplitViewOnFirstArea;
            mSplitView.SecondArea += MSplitViewOnSecondArea;
        }

        private void MSplitViewOnFirstArea(Rect obj)
        {
            obj.DrawOutline(Color.green);
            GUI.Box(obj, "FirstArea");
        }

        private void MSplitViewOnSecondArea(Rect obj)
        {
            obj.DrawOutline(Color.green);
            GUI.Box(obj, "SecondArea");
        }
    }
}