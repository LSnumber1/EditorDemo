using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(7)]
    public class XMLGUIExample : EditorWindow
    {
        const string XMLFilePath = "Assets/EditorFramework/Example/7.XMLGUI/Editor/GUIExample.xml";

        private string mXMLContent;
        public List<GUIBase> XMLGUI;

        private XMLGUI mXmlgui;
        private void OnEnable()
        {
            var xmlFileAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(XMLFilePath);
            mXMLContent = xmlFileAsset.text;
 
            
            mXmlgui = new XMLGUI();
            mXmlgui.ReadXML(mXMLContent);
            
            // mXmlgui.GetGUIBaseById<XMLGUIButton>("loginButton").OnClick += () =>
            // {
            //     Debug.Log("Login Button Clicked");
            //     mXmlgui.GetGUIBaseById<XMLGUILabel>("label1").Text = "1";
            //     mXmlgui.GetGUIBaseById<XMLGUILabel>("label2").Text = "2";
            //     mXmlgui.GetGUIBaseById<XMLGUILabel>("label3").Text = "3";
            //     mXmlgui.GetGUIBaseById<XMLGUITextField>("username").Text = "ll";
            //     mXmlgui.GetGUIBaseById<XMLGUITextArea>("description").Text = "1";
            // };  
            // var firstLine = mXmlgui.GetGUIBaseById<XMLGUILayoutHoizontalLayout>("firstLine");
            mXmlgui.GetGUIBaseById<XMLGUILayoutButton>("loginButton").OnClick += () =>
            {
                Debug.Log("Login Button Clicked");
                mXmlgui.GetGUIBaseById<XMLGUILayoutLabel>("label1").Text = "1"; 
            }; 
        }

        private void OnGUI()
        {
            mXmlgui.Draw();
        }
    }
}