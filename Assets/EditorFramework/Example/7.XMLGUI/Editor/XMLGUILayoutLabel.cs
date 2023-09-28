using System.Xml;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILayoutLabel : XMLGUIBase
    {
        public string Text;
        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            
            GUILayout.Label(Text); 
        }
        
        public override void ParseXML(XmlElement xmlElement, XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement,rootXMLGUI);
            Text = xmlElement.InnerText;
        }

        
    }
}