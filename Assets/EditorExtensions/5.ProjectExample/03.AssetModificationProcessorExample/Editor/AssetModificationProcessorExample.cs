using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

namespace EditorExtensions
{
    public class AssetModificationProcessorExample : UnityEditor.AssetModificationProcessor
    {
        private static void OnWillCreateAsset(string assetName)
        {
            Debug.Log($"OnWillCreateAsset{assetName}");
        }

        // private static AssetDeleteResult OnWillDeleteAsset(string assetPath, RemoveAssetOptions options)
        // {
        //     Debug.Log($"OnWillDeleteAsset{assetPath}{options}");
        //     if (EditorUtility.DisplayDialog("delete", "Are you sure delete?", "OK", "Cancel"))
        //     {
        //         return AssetDeleteResult.DidNotDelete;
        //     }
        //     else
        //     {
        //         return AssetDeleteResult.DidNotDelete;
        //     }
        // }
        //
        // private static AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
        // {
        //     Debug.Log($"OnWillMoveAsset{sourcePath}{destinationPath}");
        //     if (EditorUtility.DisplayDialog("Move", "Are you sure move?", "OK", "Cancel"))
        //     {
        //         return AssetMoveResult.DidMove;
        //     }
        //     else
        //     {
        //         return  AssetMoveResult.DidNotMove;
        //     }
        // }
        //
        // private static string[] OnWillSaveAssets(string[] paths)
        // {
        //     Debug.Log($"OnWillSaveAssets{paths}");
        //     return paths;
        // }
        //
        // private static bool CanOpenForEdit(string[] paths, List<string> outNotEditablePaths, StatusQueryOptions statusQueryOptions)
        // {
        //     Debug.Log($"CanOpenForEdit{paths}");
        //     return true;
        // }
        //
        // private static void FileModeChanged(string[] paths, FileMode mode)
        // {
        //     Debug.Log($"FileModeChanged{paths}{mode}");
        // }
    }
}
