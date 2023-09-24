using EditorFramework; 
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    [CustomEditorWindow(2)]
    public class GUIBaseExample : EditorWindow
    {
         public class  Label : GUIBase
         {
             private string mText;
             public Label(string text)
             {
                 mText = text;
             }
             
             public override void OnGUI(Rect position)
             {
                 GUILayout.Label(mText);
             }

             protected override void OnDispose()
             {
                 mText = null;
             }
         }

         Label mLabel = new Label("zi ding yi ");
         Label mLabel2 = new Label("zi ding yi2 ");
         private void OnGUI()
         {
             mLabel.OnGUI(default);
             mLabel2.OnGUI(default);
         }
    }
}