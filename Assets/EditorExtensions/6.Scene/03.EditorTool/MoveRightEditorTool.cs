using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace EditorExtensions
{
    [EditorTool("Move Right Editor Tool")]
    public class MoveRightEditorTool : EditorTool
    {
        public override void OnToolGUI(EditorWindow window)
        {
            // base.OnToolGUI(window);
            window.ShowNotification(new GUIContent("Move Right Editor Tool"));

            EditorGUI.BeginChangeCheck();
            Vector3 position = Tools.handlePosition;
            using (new Handles.DrawingScope(Color.green))
            {
                position = Handles.Slider(position, Vector3.right);
            }

            if (EditorGUI.EndChangeCheck())
            {
                Vector3 delta = position - Tools.handlePosition;
                Undo.RecordObjects(Selection.transforms, "Move Platform");

                foreach (var transform in Selection.transforms)
                {
                    transform.position += delta;
                }
            }
            
        }
    }

}
