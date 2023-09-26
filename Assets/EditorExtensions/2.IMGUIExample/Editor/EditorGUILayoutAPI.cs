using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class EditorGUILayoutAPI
    {
        private BuildTargetGroup mBuildTargetGroupValue;
        public void Draw()
        {
            mBuildTargetGroupValue = EditorGUILayout.BeginBuildTargetSelectionGrouping();
            EditorGUILayout.EndBuildTargetSelectionGrouping();
        }
    }

}
