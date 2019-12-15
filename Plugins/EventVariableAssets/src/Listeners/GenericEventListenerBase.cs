using UnityEngine;
using UnityEngine.Events;

namespace EventVariableAssets
{
    public class GenericEventListenerBase : MonoBehaviour
    {
        [HideInInspector][SerializeField] readonly string m_version = string.Empty; //Set in constructor
        public string Version { get => m_version; }
        public GenericEvent Event;

        public GenericEventListenerBase()
        {
            m_version = Globals.Version;
        }

        void OnEnable()
        {
            Event.RegisterListener(this);
        }

        void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public virtual void OnEventRaised() { }

        public void ClearChildren()
        {
            ClearChildren(this.transform);
        }

        public void ClearChildren(Transform t)
        {
            RectTransform[] children = t.GetComponentsInChildren<RectTransform>(true);
            for (int i = children.Length - 1; i >= 0; i--)
            {
                if (children[i].gameObject != t.gameObject)
                    DestroyImmediate(children[i].gameObject);
            }
        }
    }
}