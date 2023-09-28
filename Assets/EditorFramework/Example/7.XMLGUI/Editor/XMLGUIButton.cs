using System;
using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUIButton : XMLGUIBase
    {
        public string Text;
 
        public override void ParseXML(XmlElement xmlElement, XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement,rootXMLGUI);
            Text = xmlElement.InnerText;
        }

        public event Action OnClick; 

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            if (GUI.Button(position,Text))
            {
                Debug.Log("Button Clicked");
                if (OnClick != null)
                {
                    OnClick();
                }
            }
        }

        protected override void OnDispose()
        {
            
        }
    } 
}