using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(8)]
    public class SearchFieldExample : EditorWindow
    {
        SearchField mSearchField;
        
        private string mSearchContent = "";
        private string[] mSearchableContents = new string[] {"A", "B", "C", "D", "E"};

        private void OnEnable()
        {
            mSearchField = new SearchField(mSearchContent, mSearchableContents, 0);
            mSearchField.OnValueChanged += OnValueChanged;
            mSearchField.OnModeChanged += OnModeChanged;
            mSearchField.OnEndEdit += OnEndEdit;
        }

        private void OnEndEdit(string obj)
        {
            Debug.Log("OnEndEdit");
        }

        private void OnModeChanged(int obj)
        {
           Debug.Log("OnModeChanged"); 
        }

        private void OnValueChanged(string obj)
        {
            Debug.Log("OnValueChanged");
        }

        private void OnGUI()
        {
            GUILayout.Label("SearchField Example");
            mSearchField.OnGUI(EditorGUILayout.GetControlRect(GUILayout.Height(20)));
        }
    } 
}

