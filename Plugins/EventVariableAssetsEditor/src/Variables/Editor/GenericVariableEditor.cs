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
        const string valueFieldName = "Value";
        const string valueComplex = "<Complex value>";
        const string valueHasChangedLabel = "Has Changed";
        const string assetVersionLabel = "This Asset Version";

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GenericVariable cmp = (GenericVariable)target;

            //Draw value field
            Type baseType = GenericVariable.GetBaseType(cmp);
            if      (baseType == typeof(float))     cmp.Value = EditorGUILayout.FloatField(valueFieldName, (float)cmp.Value);
            else if (baseType == typeof(int))       cmp.Value = EditorGUILayout.IntField(valueFieldName, (int)cmp.Value);
            else if (baseType == typeof(string))    cmp.Value = EditorGUILayout.TextField(valueFieldName, (string)cmp.Value);
            else if (baseType == typeof(bool))      cmp.Value = EditorGUILayout.Toggle(valueFieldName, (bool)cmp.Value);
            else
            {
                GUI.enabled = false;
                EditorGUILayout.LabelField(valueFieldName, valueComplex);
                GUI.enabled = true;
            }

            GUI.enabled = false;
            EditorGUILayout.Toggle(valueHasChangedLabel, cmp.HasChanged);
            try
            {
                EditorGUILayout.LabelField(assetVersionLabel, cmp.Version);
            }
            catch
            {
                EditorGUILayout.LabelField(assetVersionLabel, "--");
            }
            GUI.enabled = true;

            if (Globals.VersionNum > new Version(cmp.Version))
            {
                if (GUILayout.Button(string.Format("Upgrade Asset Version ({0} > {1})"
                    , cmp.Version
                    , Globals.Version))
                    )
                {
                    if (cmp.UpgradeAsset())
                    {
                        EditorUtility.SetDirty(target);
                    }
                }
            }
        }

        public override bool RequiresConstantRepaint()
        {
            return true;
        }
    }
}