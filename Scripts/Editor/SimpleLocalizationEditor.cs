using System.Linq;
using UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Extras;
using UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Utils.Extensions;
using UnityEditor;
using UnityEngine;
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

            var tableRefProp = property.FindPropertyRelative("m_TableReference").FindPropertyRelative("m_TableCollectionName");
            var tableEntryRefKeyProp = property.FindPropertyRelative("m_TableEntryReference").FindPropertyRelative("m_Key");
            var tableEntryRefKeyIdProp = property.FindPropertyRelative("m_TableEntryReference").FindPropertyRelative("m_KeyId");


            var table = DrawTables(position, tableRefProp);
            if (table is not null)
            {
                var entry = DrawEntries(position, table, tableEntryRefKeyProp, tableEntryRefKeyIdProp);
                if (entry is not null)
                {
                    var rect = new Rect(position.x, position.y + 20f, position.width, 20f);
                    EditorGUI.LabelField(rect, entry.Value);
                }
            }

            EditorGUI.EndProperty();
        }

        private StringTable DrawTables(Rect position, SerializedProperty tableRefProp)
        {
            var tables = LocalizationSettings.StringDatabase.GetAllTables().WaitForCompletion();
            var tableRect = new Rect(position.x, position.y, position.width / 2f - 2.5f, 20f);
            var tableIndex = tables.IndexOf(x => x.TableCollectionName == tableRefProp.stringValue);
            var newTableIndex = EditorGUI.Popup(tableRect, tableIndex, tables.Select(x => x.TableCollectionName).ToArray());
            if (tableIndex != newTableIndex)
            {
                tableRefProp.stringValue = newTableIndex < 0 ? null : tables[newTableIndex].TableCollectionName;
                EditorUtility.SetDirty(tableRefProp.serializedObject.targetObject);
            }

            return newTableIndex < 0 ? null : tables[newTableIndex];
        }

        private StringTableEntry DrawEntries(Rect position, StringTable table, SerializedProperty tableEntryRefKeyProp, SerializedProperty tableEntryRefKeyIdProp)
        {
            var entries = table.Values.ToArray();
            var entryRect = new Rect(position.x + position.width / 2f + 2.5f, position.y, position.width / 2f, 20f);
            var entryIndex = entries.IndexOf(x => x.Key == tableEntryRefKeyProp.stringValue && x.KeyId == tableEntryRefKeyIdProp.longValue);
            var newEntryIndex = EditorGUI.Popup(entryRect, entryIndex,entries.Select(x => x.Key).ToArray());
            if (entryIndex != newEntryIndex)
            {
                tableEntryRefKeyProp.stringValue = newEntryIndex < 0 ? null : entries[newEntryIndex].Key;
                tableEntryRefKeyIdProp.longValue = newEntryIndex < 0 ? -1L : entries[newEntryIndex].KeyId;
                EditorUtility.SetDirty(tableEntryRefKeyProp.serializedObject.targetObject);
            }

            return newEntryIndex < 0 ? null : entries[newEntryIndex];
        }
    }
#endif
}