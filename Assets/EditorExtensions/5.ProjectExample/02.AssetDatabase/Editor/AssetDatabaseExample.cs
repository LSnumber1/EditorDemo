using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class AssetDatabaseExample : MonoBehaviour
    {
        const string FolderPath = "Assets/EditorExtensions/5.ProjectExample/02.AssetDatabase";
        const string FolderName = "NewFolder";
        private const string NewFolderPath = FolderPath +"/" +FolderName;
        private const string NewMaterialPath = NewFolderPath +"/" +"/New Material.mat";

        private const string MENU_PAT = "EditorExtensions/03.Project/01.AssetDatabase";
        
        [MenuItem(MENU_PAT +"/CreateMaterial")]
        static void CreateMaterial()
        {
            if (!Directory.Exists(NewFolderPath))
            {
                string guid = AssetDatabase.CreateFolder(FolderPath, FolderName);
                if (!string.IsNullOrEmpty(AssetDatabase.GUIDToAssetPath(guid)))
                {
                    print("CreateFolder Success");
                }
                else
                {
                    print("CreateFolder Failed");
                }
            }

            var material = new Material(Shader.Find("Specular"));
            AssetDatabase.CreateAsset(material, NewMaterialPath);

            if (AssetDatabase.Contains(material))
            {
                print(material.name + " CreateAsset Success");
            }
            else
            {
                print(material.name + " CreateAsset Failed");
            }
        }

        [MenuItem(MENU_PAT + "/GetMaterialGUID")]
        static void GetGUID()
        {
            Debug.Log(AssetDatabase.AssetPathToGUID(NewMaterialPath));
        }
        
        [MenuItem(MENU_PAT + "/LoadMaterial")]
        static void Load()
        {
            Debug.Log(AssetDatabase.LoadAssetAtPath<Material>(NewMaterialPath));
        }
        
        [MenuItem(MENU_PAT + "/RenameMaterial")]
        static void Rename()
        {
            Debug.Log(AssetDatabase.RenameAsset(NewMaterialPath, "NewName"));
        }
        
        [MenuItem(MENU_PAT + "/MoveMaterial")]
        static void Move()
        {
            Debug.Log(AssetDatabase.MoveAsset(NewMaterialPath, "Assets/move.mat"));
        }
        
        [MenuItem(MENU_PAT + "/CopyMaterial")]
        static void Copy()
        {
            Debug.Log(AssetDatabase.CopyAsset(NewMaterialPath, "Assets/copy.mat"));
        }
        
        [MenuItem(MENU_PAT + "/DeleteMaterial")]
        static void Delete()
        {
            // AssetDatabase.MoveAssetToTrash(NewMaterialPath);
            AssetDatabase.DeleteAsset(NewMaterialPath);
            AssetDatabase.Refresh();
        }
        
        [MenuItem(MENU_PAT + "/GetMaterialGUID", validate = true)]
        [MenuItem(MENU_PAT + "/LoadMaterial", validate = true)]
        [MenuItem(MENU_PAT + "/RenameMaterial", validate = true)]
        [MenuItem(MENU_PAT + "/MoveMaterial", validate = true)]
        [MenuItem(MENU_PAT + "/CopyMaterial", validate = true)]
        static bool Check()
        {
            return File.Exists(NewMaterialPath);
        }
    }
}

