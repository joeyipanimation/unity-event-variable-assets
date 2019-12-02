using UnityEngine;
using UnityEditor;

namespace EventVariableAssets
{
    [CustomEditor(typeof(GenericEvent), editorForChildClasses: true)]
    public class GenericEventEditor : Editor
    {
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
        }
    }
}