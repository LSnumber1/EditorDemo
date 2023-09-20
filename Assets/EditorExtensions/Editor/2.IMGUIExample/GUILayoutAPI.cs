using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorExtensions
{
    public class GUILayoutAPI
    {
        #region Basic

        private string mTextFieldValue;
        private string mTextAreaValue;
        private string mPasswordValue = "";
        private Vector2 mScrollPosition;
        private float mSliderValue;
        private int mToolbarIndex;
        private bool mToggleValue;
        private int mSelectionGridIndex;
 
        public void Draw()
        {
            GUILayout.Label("Label: Hello IMGUI");

            mScrollPosition = GUILayout.BeginScrollView(mScrollPosition);
            {
                GUILayout.BeginVertical();
                {
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("TextField: ");
                        mTextFieldValue = GUILayout.TextField(mTextFieldValue);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.Space(10);

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("TextArea: ");
                        mTextAreaValue = GUILayout.TextArea(mTextAreaValue);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("PasswordField: ");
                        mPasswordValue = GUILayout.PasswordField(mPasswordValue, '*');
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("Button: ");
                        GUILayout.FlexibleSpace();
                        if (GUILayout.Button("Button", GUILayout.MinWidth(100), GUILayout.MinHeight(100),
                                GUILayout.MaxWidth(150), GUILayout.MaxHeight(150)))
                        {
                            Debug.Log("Button Clicked");
                        }
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("RepeatButton: ");
                        if (GUILayout.RepeatButton("RepeatButton", GUILayout.Width(100), GUILayout.Height(50)))
                        {
                            Debug.Log("RepeatButton Clicked");
                        }
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("Box");
                        GUILayout.Box("AutoLayout Box");
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("HorizobtalSlider: ");
                        mSliderValue = GUILayout.HorizontalSlider(mSliderValue, 0, 1);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("VerticalSlider: ");
                        mSliderValue = GUILayout.VerticalSlider(mSliderValue, 0, 1);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginArea(new Rect(0, 0, 100, 100));
                    {
                        GUI.Label(new Rect(0, 0, 20, 20), "1");
                    }
                    GUILayout.EndArea();

                    GUILayout.Window(1, new Rect(0, 0, 100, 100), id => { }, "2");

                    mToolbarIndex = GUILayout.Toolbar(mToolbarIndex, new[] {"1", "3", "4"});
                    mToggleValue = GUILayout.Toggle(mToggleValue, "Toggle");

                    mSelectionGridIndex = GUILayout.SelectionGrid(mSelectionGridIndex, new[]
                    {
                        "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15"
                    }, 5);
                }
                GUILayout.EndVertical();
            }
            GUILayout.EndScrollView();
        }

        #endregion
    }
}