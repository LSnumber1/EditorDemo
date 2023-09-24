using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class GUIContentAndGUIStyleExample : EditorWindow 
    {
        [MenuItem("EditorExtensions/02.IMGUI/02.GUIContentAndGUIStyleExample")]
        static void Open()
        {
            GetWindow<GUIContentAndGUIStyleExample>().Show();
        }

        enum Mode
        {
            GUIContent,
            GUIStyle,
        }
        private int mToolbarIndex;

        private GUIStyle mBoxStyle = "box";

        private Lazy<GUIStyle> mFontStyle = new Lazy<GUIStyle>(() =>
        {
            var retStyle = new GUIStyle("label");
            retStyle.fontSize = 30;
            retStyle.fontStyle = FontStyle.BoldAndItalic;
            retStyle.normal.textColor = Color.green;
            retStyle.hover.textColor = Color.red;
            retStyle.focused.textColor = Color.magenta;
            retStyle.active.textColor = Color.cyan;
            retStyle.normal.background = Texture2D.whiteTexture;
            return retStyle;
        });
        
        private Lazy<GUIStyle> mButtonStyle = new Lazy<GUIStyle>(() =>
        {
            var retStyle = new GUIStyle(GUI.skin.button);
            retStyle.fontSize = 30;
            retStyle.fontStyle = FontStyle.BoldAndItalic;
            retStyle.normal.textColor = Color.green;
            retStyle.hover.textColor = Color.red;
            retStyle.focused.textColor = Color.magenta;
            retStyle.active.textColor = Color.cyan;
            retStyle.normal.background = Texture2D.whiteTexture;
            return retStyle;
        });

        private void OnGUI()
        {
            mToolbarIndex = GUILayout.Toolbar(mToolbarIndex, Enum.GetNames(typeof(Mode)));

            if (mToolbarIndex == (int)Mode.GUIContent)
            {
                GUILayout.Label("GUIContent");
                GUILayout.Label(new GUIContent("GUIContent"));
                GUILayout.Label(new GUIContent("GUIContent", "Yeah"));
                GUILayout.Label(new GUIContent("GUIContent", Texture2D.whiteTexture));
                GUILayout.Label(new GUIContent("GUIContent", Texture2D.whiteTexture, "Yeah"));
            }
            else
            {
                GUILayout.Label("Style of defalut");
                GUILayout.Label("Style of box", mBoxStyle);
                GUILayout.Label("Style of font", mFontStyle.Value);
                if (GUILayout.Button("Button of font", mButtonStyle.Value))
                {
                    Debug.Log("Button of font");
                }
            }
        }
    }

}
