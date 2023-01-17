using UnityEditor;
using UnityEngine;

namespace MobileFramework.Subclass
{
    [CustomPropertyDrawer(typeof(SubclassOfAttribute))]
    public class SubclassOfAttributeDrawer : PropertyDrawer
    {
        private string[] names = null;
        private int index;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var atb = attribute as SubclassOfAttribute;

            names = SubclassUtility.GetSubclassesNames(atb.Type).ToArray();
            property.intValue = EditorGUI.Popup(position, property.name, property.intValue, names);
            
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);
        }
    }
}