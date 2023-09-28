using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace EditorExtensions
{
    public class TreeViewExample : EditorWindow
    {
        [MenuItem("EditorExtensions/12.TreeView/Open")]
        static void Open()
        {
            GetWindow<TreeViewExample>().Show();
        }
        [SerializeField]
        TreeViewState mTreeViewState;
        SimpleTreeView mSimpleTreeView;
        SearchField mSearchField;

        private void OnEnable()
        {
            if (mTreeViewState == null)
            {
                mTreeViewState = new TreeViewState();
            }
            
            mSimpleTreeView = new SimpleTreeView(mTreeViewState);
            mSearchField = new SearchField();
            mSearchField.downOrUpArrowKeyPressed += mSimpleTreeView.SetFocusAndEnsureSelectedItem;
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal(EditorStyles.toolbar);
            GUILayout.Space(100);
            GUILayout.FlexibleSpace();
            mSimpleTreeView.searchString = mSearchField.OnToolbarGUI(mSimpleTreeView.searchString);
            GUILayout.EndHorizontal();
            var rect = GUILayoutUtility.GetRect(0, 100000, 0, 100000);
            mSimpleTreeView.OnGUI(rect);
        }

        public class SimpleTreeView: TreeView
        {
            public SimpleTreeView(TreeViewState state) : base(state)
            {
                Reload();
            }

            public SimpleTreeView(TreeViewState state, MultiColumnHeader multiColumnHeader) : base(state, multiColumnHeader)
            {
            }

            protected override TreeViewItem BuildRoot()
            {
                var root = new TreeViewItem(0, -1, "Root");
                var allItem = new List<TreeViewItem>()
                {
                    new TreeViewItem(1, 0, "Item1"),
                    new TreeViewItem(2, 0, "Item2"),
                    new TreeViewItem(3, 0, "Item3"),
                    new TreeViewItem(4, 1, "Item4"),
                    new TreeViewItem(5, 2, "Item5"),
                    new TreeViewItem(6, 2, "Item6"),
                    new TreeViewItem(7, 1, "Item7"),
                    new TreeViewItem(8, 2, "Item8"),
                    new TreeViewItem(9, 0, "Item9"),
                };
                
                SetupParentsAndChildrenFromDepths(root, allItem);
                return root;
            }
        }
    } 
}

