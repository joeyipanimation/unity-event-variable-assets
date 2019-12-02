using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EventVariableAssets
{
    [CustomEditor(typeof(GenericVariable), editorForChildClasses: true)]
    public class GenericVariableEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GenericVariable cmp = (GenericVariable)target;
            //Type baseType = GenericVariable.GetBaseType(cmp);

            ////Draw value field
            //if      (baseType == typeof(float))     EditorGUILayout.FloatField("Value", (float)cmp.Value);
            //else if (baseType == typeof(int))       EditorGUILayout.IntField("Value", (int)cmp.Value);
            //else if (baseType == typeof(string))    EditorGUILayout.TextField("Value", (string)cmp.Value);
            //else if (baseType == typeof(bool))      EditorGUILayout.Toggle("Value", (bool)cmp.Value);
            //else                                    base.OnInspectorGUI();

            GUI.enabled = false;
            EditorGUILayout.Toggle("Has Changed", cmp.HasChanged);
            GUI.enabled = true;
        }
    }
}