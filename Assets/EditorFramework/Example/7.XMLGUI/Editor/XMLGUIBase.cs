using System.Xml;
using NUnit.Framework;
using UnityEngine;

namespace EditorFramework
{
    
    public class XMLGUIBase : GUIBase
    {
        protected T GetAttributeValue<T>(XmlElement xmlElement, string attibuteName)
        {
            var attributeValue = xmlElement.GetAttribute(attibuteName);
            if (!string.IsNullOrEmpty(attributeValue))
            {
                T result = default;
                if (attributeValue.TryConvert<T>(out result))
                {
                    return result;
                }
            } 
            return default;
        }
        
        public virtual void ParseXML(XmlElement xmlElement, XMLGUI rootXMLGUI)
        {
            Id = GetAttributeValue<string>(xmlElement, "id");
            mPosition = GetAttributeValue<Rect>(xmlElement, "position");
        }
        public string Id;

        protected override void OnDispose()
        {
            
        }

        public void SetPosition(Rect position)
        {
            mPosition = position;
        }

        public void Draw()
        {
             OnGUI(mPosition);
        }
    }
}