using System.Collections.Generic;
using MobileFramework.Subclass;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MoveSO))]
public class MoveSOEditor : Editor
{
    private List<string> subclasses;
    private int index = 0;
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var so = (MoveSO)target;
        
        var types = SubclassUtility.GetSubclassesOf<MoveBlock>();

        subclasses = new List<string>();
            
        foreach (var type in types)
        {
            subclasses.Add(type.Name);
        }
        
        GUILayout.FlexibleSpace();
        EditorGUILayout.BeginHorizontal();

        index = EditorGUILayout.Popup(index, subclasses.ToArray());
        if (GUILayout.Button($"Add Block"))
        {
            so.moveBlocks.Add(SubclassUtility.GetSubclassFromIndex<MoveBlock>(index));
        }
        EditorGUILayout.EndHorizontal();

    }
}

