using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    [CustomPreview(typeof(GameObject))]
    public class ObjectPreviewExample : ObjectPreview
    {
        public override bool HasPreviewGUI()
        {
            // return base.HasPreviewGUI();
            return true;
        }

        public override void OnPreviewGUI(Rect r, GUIStyle background)
        {
            // base.OnPreviewGUI(r, background);
            GUI.Label(r, target.name + "Hello World");
        }
    }
}