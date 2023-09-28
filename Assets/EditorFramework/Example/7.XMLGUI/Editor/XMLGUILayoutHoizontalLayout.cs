using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILayoutHoizontalLayout :XMLGUIContainerBase
    {
        public bool Box;
        public override void ParseXML(XmlElement xmlElement, XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement, rootXMLGUI);
            Box = GetAttributeValue<bool>(xmlElement, "box");
        }
        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            if (Box)
            {
                GUILayout.BeginHorizontal("Box");
            }
            else
            {
                GUILayout.BeginHorizontal();
            } 

            // XMLGUI.Draw();

            GUILayout.EndHorizontal();
        }
    }
}