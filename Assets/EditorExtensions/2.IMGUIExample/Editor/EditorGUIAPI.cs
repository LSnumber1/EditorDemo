using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class EditorGUIAPI
    {
        private Rect mLabelRect = new Rect(10, 80, 200, 20);

        private bool mDisableGroupValue = false;
        public void Draw()
        {
           
            mDisableGroupValue = EditorGUILayout.Toggle("DisableGroup", mDisableGroupValue);
            EditorGUI.BeginDisabledGroup(mDisableGroupValue);
            {
                EditorGUI.LabelField(mLabelRect, "LabelField");
            }
            EditorGUI.EndDisabledGroup();
        }
    }
}