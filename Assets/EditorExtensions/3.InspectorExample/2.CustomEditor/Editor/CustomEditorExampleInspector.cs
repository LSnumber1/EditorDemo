using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    [CustomEditor(typeof(CustomEditorExample))]
    public class CustomEditorExampleInspector : Editor
    {
        CustomEditorExample mTarget
        {
            get{return  target as CustomEditorExample;}
        }
     

    public override void OnInspectorGUI()
        {
            // base.OnInspectorGUI();

            var hpRect = GUILayoutUtility.GetRect(18, 18, "TextField"); 
            EditorGUI.ProgressBar(hpRect,  mTarget.HP, "HP");
            
            var rangeRect = GUILayoutUtility.GetRect(18, 18, "TextField"); 
            EditorGUI.ProgressBar(rangeRect,  mTarget.Range, "Range");

            EditorGUILayout.BeginHorizontal("box");
            EditorGUILayout.LabelField("RoleName", GUILayout.Width(100));
            mTarget.RoleName = EditorGUILayout.TextArea(mTarget.RoleName);
            EditorGUILayout.EndHorizontal();
            
            // var serializedObject = new SerializedObject(target);
            var other = serializedObject.FindProperty("OtherObj");
            EditorGUILayout.ObjectField(other);

            serializedObject.ApplyModifiedProperties();
        }
    } 

}
