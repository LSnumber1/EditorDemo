using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    [InitializeOnLoad]
    public class ProjectExample 
    {
        static ProjectExample()
        {
            Menu.SetChecked(PATH, mCustomProjectEnabled);
        }
        private const string PATH = "EditorExtensions/02.IMGUI/04.Enable Custom Project";
        
        static bool mCustomProjectEnabled = false;

        [MenuItem(PATH)]
        static void Enable()
        {
            if (mCustomProjectEnabled)
            {
                mCustomProjectEnabled = false;
                UnRegisterProject();
            }
            else
            {
                mCustomProjectEnabled = true;
                RegisterProject(); 
            }
            Menu.SetChecked(PATH, mCustomProjectEnabled);
            EditorApplication.RepaintProjectWindow();
        }
        
        static void RegisterProject()
        {
            EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemOnGUI;
            EditorApplication.projectChanged += OnProjectChanged;
        }

        private static void OnProjectChanged()
        {
            
        }

        static void UnRegisterProject()
        {
            EditorApplication.projectWindowItemOnGUI -= OnProjectWindowItemOnGUI;
            EditorApplication.projectChanged -= OnProjectChanged;
        } 
        
        private static void OnProjectWindowItemOnGUI(string guid, Rect selectionrect)
        {
            try
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var files = Directory.GetFiles(assetPath);
                var countLabelRect = selectionrect;
                countLabelRect.x += 150;
                GUI.Label(countLabelRect, files.Length.ToString()); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e); 
            }
           
        }
    }

}
