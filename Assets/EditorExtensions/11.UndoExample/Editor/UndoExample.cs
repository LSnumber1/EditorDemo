using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    
    public class UndoExample 
    {
        [MenuItem("EditorExtensions/07.Undo/Create Obj")]
        static void CreateObj()
        {
            var newObj = new GameObject("Undo");
            Undo.RegisterCreatedObjectUndo(newObj, "CreateObj");
        }
        
        [MenuItem("EditorExtensions/07.Undo/Move Obj")]
        static void Move()
        {
            var trans = Selection.activeGameObject.transform;
            if (trans)
            {
                Undo.RecordObject(trans, "MoveObj");
                trans.position += Vector3.up;
            }
        }
        
        [MenuItem("EditorExtensions/07.Undo/AddComponent Obj")]
        static void AddComponent()
        {
            var selectedObj = Selection.activeGameObject;
            if (selectedObj)
            {
                Undo.AddComponent(selectedObj, typeof(Rigidbody));
            } 
        }
        
        [MenuItem("EditorExtensions/07.Undo/Destroy Component Obj")]
        static void DestroyComponent()
        {
            var selectedObj = Selection.activeGameObject;
            if (selectedObj)
            {
               Undo.DestroyObjectImmediate(selectedObj);
            } 
        }
        
        [MenuItem("EditorExtensions/07.Undo/SetParent Component Obj")]
        static void SetParentComponent()
        { 
            var trans = Selection.activeGameObject.transform;
            var root = Camera.main.transform;
            if (trans)
            {
                Undo.SetTransformParent(trans, root, trans.name);
            } 
        }
        
        [MenuItem("EditorExtensions/07.Undo/SetParent Component Obj",validate = true)]
        [MenuItem("EditorExtensions/07.Undo/Destroy Component Obj",validate = true)]
        [MenuItem("EditorExtensions/07.Undo/AddComponent Component Obj",validate = true)]
        [MenuItem("EditorExtensions/07.Undo/Move Component Obj",validate = true)] 
        static bool Check()
        {
            return Selection.activeGameObject != null;
        }
    }

}
