using System.Collections.Generic;
using System.Reflection;
using MobileFramework.Subclass;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using System.Reflection;


namespace _Scripts.Pokemon_Battle.Pokemon.Moves.MoveBlocks.Damage.Editor
{

    [CustomPropertyDrawer(typeof(MultipleDamageBlock))]
    public class MultipleDamageBlockPropertyDrawer : PropertyDrawer
    {
        private List<string> subclasses;
        private int index = 0;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var types = SubclassUtility.GetSubclassesOf<MoveBlock>();

            subclasses = new List<string>();
            
            foreach (var type in types)
            {
                subclasses.Add(type.Name);
            }

            var firstRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            var secondRect = new Rect(position.x, position.y + 20f, position.width, EditorGUIUtility.singleLineHeight);
            var thirdRect = new Rect(position.x, position.y + 40f, position.width, EditorGUIUtility.singleLineHeight);
            
            var min = property.FindPropertyRelative("min");
            var max = property.FindPropertyRelative("max");

            min.intValue = EditorGUI.IntField(firstRect,"Min" ,min.intValue);
            max.intValue = EditorGUI.IntField(secondRect,"Max" ,max.intValue);

            var list = property.FindPropertyRelative("moveBlocks");
            var moveList = SerializedPropertyExtensions.GetTargetObjectOfProperty(list) as List<MoveBlock>;
            EditorGUI.PropertyField(thirdRect, list, true);

            EditorGUILayout.LabelField($"Multiple Damage Settings");

            EditorGUILayout.BeginHorizontal();
            
            index = EditorGUILayout.Popup(index, subclasses.ToArray());
            if (GUILayout.Button($"Add Class"))
            {
                moveList.Add(SubclassUtility.GetSubclassFromIndex<MoveBlock>(index));
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.LabelField($"------------------------------");

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            Vector2 position = Vector2.zero;
            
            foreach (SerializedProperty a in property)
            {
                position.y += 20;
            }
            
            return base.GetPropertyHeight(property, label) + position.y;
        }
    }
}