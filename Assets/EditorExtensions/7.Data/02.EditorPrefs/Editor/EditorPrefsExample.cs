using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class EditorPrefsExample
    {
        private const string key = "EditorPrefsExample";
        
        [MenuItem("EditorExtensions/04.Data/EditorPrefs/SaveTime")]
        static void SaveTime()
        {
            EditorPrefs.SetString(key, DateTime.Now.ToString());
        }
        
        [MenuItem("EditorExtensions/04.Data/EditorPrefs/ReadTime")]
        static void ReadTime()
        { 
          Debug.Log(EditorPrefs.GetString(key));
        }
    }
}

