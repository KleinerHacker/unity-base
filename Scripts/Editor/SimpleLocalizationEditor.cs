using System.Linq;
using UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Extras;
using UnityEditor;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

namespace UnityBase.Editor.Projects.unity_base.Scripts.Editor
{
#if UNITY_LOCALIZATION

    [CustomPropertyDrawer(typeof(SimpleLocalization))]
    public class LocalizationStringPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            EditorGUILayout.BeginVertical();

            var tableRefProp = property.FindPropertyRelative("m_TableReference").FindPropertyRelative("m_TableCollectionName");
            var tableEntryRefProp = property.FindPropertyRelative("m_TableEntryReference");

            
            var tables = LocalizationSettings.StringDatabase.GetAllTables().WaitForCompletion();
            var tableIndex = EditorGUI.Popup(new Rect(position.x, position.y, position.width / 2f - 2.5f, 20f), 0, tables.Select(x => x.TableCollectionName).ToArray());
            var entries = tables[tableIndex].Values;
            var entryIndex = EditorGUI.Popup(new Rect(position.x + position.width / 2f + 2.5f, position.y, position.width / 2f, 20f), 0, entries.Select(x => x.Key).ToArray());
            
            EditorGUILayout.EndVertical();
            EditorGUI.EndProperty();
        }
    }
#endif
}