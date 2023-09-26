using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public static class MenuItemExample 
    {
        [MenuItem("EditorExtensions/01.Menu/01.Hello Editor")]
        static void HelloEditor()
        {
            Debug.Log("Hello Editor");
        }

        [MenuItem("EditorExtensions/01.Menu/02.Open Bilibili")]
        static void OpenBilibili()
        {
            Application.OpenURL("https://www.bilibili.com/");
        }
        
        [MenuItem("EditorExtensions/01.Menu/03.Open PersistentDataPath")]
        static void OpenPersistentDataPath() {
            EditorUtility.RevealInFinder(Application.persistentDataPath);
        }
        
        [MenuItem("EditorExtensions/01.Menu/04.Open DesignerFolder")]
        static void OpenDesignerFolder() {
            EditorUtility.RevealInFinder(Application.dataPath.Replace("Assets", "Library"));
        }

        private static bool mOpenShotCut = false; 
        
        [MenuItem("EditorExtensions/01.Menu/05.Toggle ShotCut")]
        static void ToggleShotCut()
        {
            mOpenShotCut = !mOpenShotCut;
            Menu.SetChecked("EditorExtensions/01.Menu/05.Toggle ShotCut", mOpenShotCut);
        }
        
        [MenuItem("EditorExtensions/01.Menu/06.Hello Editor _C")]
        static void HelloEditorWithShotCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/01.Hello Editor");
        }
        
        [MenuItem("EditorExtensions/01.Menu/06.Hello Editor _C", validate =  true)]
        static bool HelloEditorWithShotCutValidate()
        {
            return mOpenShotCut;
        }
        
        [MenuItem("EditorExtensions/01.Menu/07.Open Bilibili %e")]
        static void OpenBilibiliWithShotCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/02.Open Bilibili");
            Debug.Log("OpenBilibiliWithShotCut");
        }
        
        [MenuItem("EditorExtensions/01.Menu/07.Open Bilibili %e", validate =  true)]
        static bool OpenBilibiliWithShotCutValidate()
        {
            return mOpenShotCut;
        }
        
        [MenuItem("EditorExtensions/01.Menu/08.Open PersistentDataPath %#t")]
        static void OpenPersistentDataPathWithShotCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/03.Open PersistentDataPath");
            Debug.Log("OpenPersistentDataPathWithShotCut");
        }
        
        [MenuItem("EditorExtensions/01.Menu/08.Open PersistentDataPath %#t", validate =  true)]
        static bool OpenPersistentDataPathWithShotCutValidate()
        {
            return mOpenShotCut;
        }
        
        [MenuItem("EditorExtensions/01.Menu/09.Open DesignerFolder &r")]
        static void OpenDesignerFolderPathWithShotCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/04.Open DesignerFolder");
            Debug.Log("OpenPersistentDataPathWithShotCut");
        }
        
        [MenuItem("EditorExtensions/01.Menu/09.Open DesignerFolder &r", validate =  true)]
        static bool OpenDesignerFolderPathWithShotCutValidate()
        {
            return mOpenShotCut;
        }

        static MenuItemExample()
        {
            Menu.SetChecked("EditorExtensions/01.Menu/05.Toggle ShotCut", mOpenShotCut);
        }
    }
}
