using System;
using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILayoutButton : XMLGUIBase
    {
        public string Text;
        
        public event Action OnClick; 

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            if (GUILayout.Button(Text))
            {
                Debug.Log("Button Clicked");
                if (OnClick != null)
                {
                    OnClick();
                }
            }
        }
        
        public override void ParseXML(XmlElement xmlElement, XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement,rootXMLGUI);
            Text = xmlElement.InnerText;
        }
    }
}