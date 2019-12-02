using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEditor;

namespace EventVariableAssets
{
    [CustomPropertyDrawer(typeof(ComponentProperty), useForChildren: true)]
    public class ComponentPropertyEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //Using BeginProperty / EndProperty on the parent property means that prefab override logic works on the entire property.
            EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0; //Don't make child fields be indented

            //Field sizes
            Rect cmpRect = new Rect(position.x, position.y, position.width / 2, position.height);
            Rect propRect = new Rect(position.x + (position.width / 2), position.y, position.width / 2, position.height);

            SerializedProperty cmpObj = property.FindPropertyRelative("ComponentObject");
            SerializedProperty nameProp = property.FindPropertyRelative("PropertyName");
            EditorGUI.PropertyField(cmpRect, cmpObj, GUIContent.none);

            //Dropdown options
            if (cmpObj.objectReferenceValue != null)
            {
                PropertyInfo[] props = cmpObj.objectReferenceValue.GetType().GetProperties();
                string[] s = ToString(props);
                int selectIndex = Array.IndexOf(s, nameProp.stringValue);
                int userSelectIndex = EditorGUI.Popup(propRect, selectIndex, s);
                if (userSelectIndex != selectIndex)
                {
                    nameProp.stringValue = s[userSelectIndex];
                }
            }
            else
            {
                GUI.enabled = false;
                EditorGUI.Popup(propRect, 0, new string[] { nameProp.stringValue });
                GUI.enabled = true;
            }

            //Reset indent
            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }

        string[] ToString(PropertyInfo[] p)
        {
            string[] s = new string[p.Length];
            for (int i = 0; i < p.Length; i++)
            {
                s[i] = p[i].Name;
            }
            return s;
        }
    }
}
