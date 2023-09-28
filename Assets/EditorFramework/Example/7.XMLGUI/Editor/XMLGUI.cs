using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUI
    {
        private static List<XMLGUIBase> mGUIBases = new List<XMLGUIBase>();
        private Dictionary<string, XMLGUIBase> mGUIBasesForId = new Dictionary<string, XMLGUIBase>();

        public void   Draw()
        {
            foreach (var xmlguiBase in mGUIBases)
            {
                xmlguiBase.Draw();
            }
        }
        public T GetGUIBaseById<T>(string id) where T : XMLGUIBase
        {
            XMLGUIBase t = default;
            if (mGUIBasesForId.TryGetValue(id, out t))
            {
                return t as T;
            }
            else
            {
                return default;
            }
        }

        private Dictionary<string, Func<XMLGUIBase>> mFactoriesForGUIBasseNames = new Dictionary<string, Func<XMLGUIBase>>
        {
            {"Label", () => new XMLGUILabel()},
            {"TextField", () => new XMLGUITextField()},
            {"TextArea", () => new XMLGUITextArea()},
            {"Button", () => new XMLGUIButton()},
            {"LayoutLabel", () => new XMLGUILayoutLabel()},
            {"LayoutButton", () => new XMLGUILayoutButton()},
            {"LayoutHorizontal", () => new XMLGUILayoutHoizontalLayout()},
            {"LayoutVertical", () => new XMLGUILayoutVertical()},
        };
        public void ReadXML(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var rootNode = doc.SelectSingleNode("GUI");

            ChildElementsToGUIBase(rootNode as XmlElement, this);
 
        }

        public void ChildElementsToGUIBase(XmlElement rootElement, XMLGUI rootXMLGUI)
        {
            Func<XMLGUIBase> outguibaseFactory = default;
            XMLGUIBase xmlguiBase = default; 
            foreach (XmlElement rootNodeChildNode in rootElement.ChildNodes)
            {
                if (mFactoriesForGUIBasseNames.TryGetValue(rootNodeChildNode.Name, out outguibaseFactory))
                {
                    xmlguiBase = mFactoriesForGUIBasseNames[rootNodeChildNode.Name]();
                    xmlguiBase.ParseXML(rootNodeChildNode, rootXMLGUI); 
                    ADDGUIBase(xmlguiBase,rootXMLGUI);
                } 
            }
        }
        
        void ADDGUIBase(XMLGUIBase guibase , XMLGUI rootXMLGUI)
        {
            mGUIBases.Add(guibase);
            if (!string.IsNullOrEmpty(guibase.Id))
            {
                mGUIBasesForId.Add(guibase.Id, guibase);
                if (rootXMLGUI == this)
                {
                    
                }
                else
                {
                     rootXMLGUI.mGUIBasesForId.Add(guibase.Id,guibase) ;
                }
            }
        }
    }
}