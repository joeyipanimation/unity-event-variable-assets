using System;
using UnityEngine;
using UnityEditor;

namespace EventVariableAssets
{
    [CustomEditor(typeof(GenericEvent), editorForChildClasses: true)]
    public class GenericEventEditor : Editor
    {
        const string assetVersionLabel = "This Asset Version";

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GenericEvent cmp = (GenericEvent)target;

            GUI.enabled = Application.isPlaying;
            if (GUILayout.Button("Raise Event"))
            {
                cmp.Raise();
            }
            GUI.enabled = true;

            GUILayout.Space(20);
            if (GUILayout.Button("Clear"))
            {
                cmp.ClearCallStack();
            }
            cmp.TraceCallStack = EditorGUILayout.Toggle("Trace Call Stack", cmp.TraceCallStack);
            EditorGUILayout.TextArea(cmp.CallStackStrings);

            GUI.enabled = false;
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
            GenericEvent cmp = (GenericEvent)target;
            return cmp.TraceCallStack;
        }
    }
}