using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace EditorExtensions
{
    public class AdvancedDropdownExample : EditorWindow
    {
        [MenuItem("EditorExtensions/10.AdvancedDropdown/Open")]
        static void Open()
        {
            CreateInstance<AdvancedDropdownExample>().Show();
        }

        private void OnGUI()
        {
            var rect = GUILayoutUtility.GetRect(new GUIContent("Show"), EditorStyles.toolbarButton);
            if (GUI.Button(rect, "Show"))
            {
                var dropDown = new WeekDaysDropDown(new AdvancedDropdownState());
                dropDown.Show(rect);
            }
        }

        public class WeekDaysDropDown: AdvancedDropdown 
      {
          public WeekDaysDropDown(AdvancedDropdownState state) : base(state)
          {
          }

          protected override AdvancedDropdownItem BuildRoot()
          {
              var root = new AdvancedDropdownItem("Week Days");
              var firstHarf = new AdvancedDropdownItem("First Harf");
              var secondHarf = new AdvancedDropdownItem("Second Harf");
              
              
              firstHarf.AddChild(new AdvancedDropdownItem("Monday"));
              secondHarf.AddChild(new AdvancedDropdownItem("Tuesday"));
              
              root.AddChild(firstHarf);
              root.AddChild(secondHarf);
              return root;
          }
      }
    }
  
}
