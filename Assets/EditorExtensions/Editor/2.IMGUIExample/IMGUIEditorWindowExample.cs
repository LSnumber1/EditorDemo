using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class IMGUIEditorWindowExample : EditorWindow
    {
        [MenuItem("EditorExtensions/02.IMGUI/01.GUILayoutExample")]
        static void OpenGUILayoutExample()
        {
            GetWindow<IMGUIEditorWindowExample>().Show();
        }

        enum APIMode
        {
            GUILayout,
            GUI
        }

        enum PageId
        {
            Basic,
            Other
        }

        private APIMode mCurrentAPIMode = APIMode.GUILayout;
        private PageId mCurentPageID;
        private GUILayoutAPI mGuiLayoutAPI = new GUILayoutAPI();
        private GUIAPI mGuiAPI = new GUIAPI();

        private void OnGUI()
        {
            mCurrentAPIMode = (APIMode) GUILayout.Toolbar((int) mCurrentAPIMode, Enum.GetNames(typeof(APIMode)));
            mCurentPageID = (PageId) GUILayout.Toolbar((int) mCurentPageID, Enum.GetNames(typeof(PageId)));
            if (mCurentPageID == PageId.Basic)
            {
                Basic();
            }
            else if (mCurentPageID == PageId.Other)
            {
            }
        }

        #region Basic

        void Basic()
        {
            if (mCurrentAPIMode == APIMode.GUILayout)
            {
                mGuiLayoutAPI.Draw();
            } else if (mCurrentAPIMode == APIMode.GUI)
            {
                mGuiAPI.Draw();
            }
        }


        #endregion
    }
}