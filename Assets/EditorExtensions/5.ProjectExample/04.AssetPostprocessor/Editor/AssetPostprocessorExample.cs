using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class AssetPostprocessorExample : AssetPostprocessor
    {
        private void OnPreprocessTexture()
        {
            Debug.Log($"OnPreprocessTexture{assetPath}");
            TextureImporter importer = this.assetImporter as TextureImporter;
            importer.maxTextureSize = 512;
            importer.mipmapEnabled = false;
        }

        private void OnPostprocessTexture(Texture2D texture)
        {
            Debug.Log($"OnPostprocessTexture{assetPath},{texture.name}");
        }
    }   
}

