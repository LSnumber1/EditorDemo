using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using EditorFramework;
using UnityEditor;
using UnityEngine;

[CustomEditorWindow(3)]
public class TypeExExample : EditorWindow
{
    public class DescriptionBase
    {
        public virtual string Description { set; get; }
    }
    
    public class MyDescription : DescriptionBase
    {
        public override string Description { get; set; } = "这是一个描述";
    }
   
    [MyDesc("B")]
    public class MyDescriptionB : DescriptionBase
    {
        public override string Description { get; set; } = "这是一个描述B";
    }
    
    public class MyDescAttribute : Attribute
    {
        public string Type;

        public MyDescAttribute(string type = "")
        {
            Type = type;
        }
    }
    
    private IEnumerable<Type> mDescriptionTypes;
    private IEnumerable<Type> mDescriptionTypesWithAttribute;
    private void OnEnable()
    {
        mDescriptionTypes = typeof(DescriptionBase).GetSubTypesInAssemblies();
        mDescriptionTypesWithAttribute = typeof(DescriptionBase).GetSubTypesWithClassInAssemblies<MyDescAttribute>();
    }

    private void OnGUI()
    {
        GUILayout.Label("Types");
        foreach (var variabDescriptionType in mDescriptionTypes)
        {
            GUILayout.BeginHorizontal("box");
            {
                GUILayout.Label(variabDescriptionType.Name);
            }
            GUILayout.EndHorizontal(); 
        }

        GUILayout.Label("With Attribute");
        foreach (var descriptionType in mDescriptionTypesWithAttribute)
        {
            GUILayout.BeginHorizontal("box");
            {
                GUILayout.Label(descriptionType.Name);
                GUILayout.Label(descriptionType.GetCustomAttribute<MyDescAttribute>().Type);
            }
            GUILayout.EndHorizontal();  
        }
    }
}
