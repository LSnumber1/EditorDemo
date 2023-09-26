using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorExtensions
{
    public class IMGUIRuntimeExample : MonoBehaviour
    {
        private GUILayoutAPI mGUILayout = new GUILayoutAPI();
        private GUIAPI mGUIAPI = new GUIAPI();

        private int mIndex = 0;
        private void OnGUI()
        {
            mIndex = GUILayout.Toolbar(mIndex, new[] {"GUILayoutAPI", "GUIAPI"});
            if (mIndex == 0)
            {
                mGUILayout.Draw();
            }
            else
            {
                mGUIAPI.Draw();
            }
        }
    }
}
