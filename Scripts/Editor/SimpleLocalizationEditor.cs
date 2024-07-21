using UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Extras;
using UnityEditor;
using UnityEngine;
using UnityEngine.Localization;

namespace UnityBase.Editor.Projects.unity_base.Scripts.Editor
{
#if UNITY_LOCALIZATION
    [CustomPropertyDrawer(typeof(SimpleLocalization))]
    public sealed class SimpleLocalizationEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var x = property.FindPropertyRelative("m_TableReference");
            EditorGUI.PropertyField(position, x);
        }
    }
#endif
}