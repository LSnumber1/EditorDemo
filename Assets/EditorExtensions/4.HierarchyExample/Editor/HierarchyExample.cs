using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    [InitializeOnLoad]
    public class HierarchyExample
    {
        static bool mCustomHierarchyEnabled = false;

        private const string PATH = "EditorExtensions/02.IMGUI/03.Enable Custom Hierarchy";
        static HierarchyExample()
        {
            Menu.SetChecked(PATH, mCustomHierarchyEnabled);
        }
        
        [MenuItem(PATH)]
        static void EnableCustomHierarchy()
        {
            if (mCustomHierarchyEnabled)
            {
                mCustomHierarchyEnabled = false;
                UnRegisterHierarchy();
            }
            else
            {
                mCustomHierarchyEnabled = true;
                RegisterHierarchy();
            }
           
            Menu.SetChecked(PATH, mCustomHierarchyEnabled);
            
            EditorApplication.RepaintHierarchyWindow();
        }

        static void RegisterHierarchy()
        {
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindowItemOnGUI;
            EditorApplication.hierarchyChanged += OnHierarchyChanged;
        }

        private static void OnHierarchyChanged()
        {
             // Debug.Log("OnHierarchyChanged");
        }

        static void UnRegisterHierarchy()
        {
            EditorApplication.hierarchyWindowItemOnGUI -= OnHierarchyWindowItemOnGUI;
        }
        
        private static void OnHierarchyWindowItemOnGUI(int instanceid, Rect selectionrect)
        {
            var obj = EditorUtility.InstanceIDToObject(instanceid) as GameObject;

            if (obj)
            {
                var tagLabelRect = selectionrect;
                tagLabelRect.x += 150;
            
                GUI.Label(tagLabelRect, obj?.tag);

                var layerLabelRect = tagLabelRect;
                layerLabelRect.x += 150;
                GUI.Label(layerLabelRect, LayerMask.LayerToName(obj.layer));
            } 
        }
    }
}