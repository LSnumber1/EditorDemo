using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace EditorExtensions
{
    [InitializeOnLoad]
    public class EditorEventAttributeExample
    {
        static EditorEventAttributeExample()
        {
            Debug.Log("EditorEventAttributeExample");
        }
        
        [InitializeOnLoadMethod]
        static void InitializeOnLoadMethod()
        {
            Debug.Log("InitializeOnLoadMethod");
        }
        
        [DidReloadScripts]
        static void OnReloadScripts()
        {
            Debug.Log("OnReloadScripts");
        }
        
        [PostProcessScene]
        static void OnPostProcessScene()
        {
            Debug.Log("OnPostProcessScene");
        }
        
        [PostProcessBuild]
        static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
        {
            Debug.Log("PostProcessBuild");
        }
        
        [OnOpenAsset(1)]
        static bool OpenAsset(int instanceID, int line)
        {
            var name = EditorUtility.InstanceIDToObject(instanceID).name;
            Debug.Log("Open Asset step:1 (" + name + ")");
            return false;
        }
        [OnOpenAsset(2)]
        static bool OpenAsset2(int instanceID, int line)
        {
            var name = EditorUtility.InstanceIDToObject(instanceID).name;
            Debug.Log("Open Asset step:2 (" + name + ")");
            return false;
        }
    }  
}

