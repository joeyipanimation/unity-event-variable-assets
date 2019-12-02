using System.Collections.Generic;
using UnityEngine;

namespace EventVariableAssets
{
    [CreateAssetMenu(fileName = "NewGenericEvent", menuName = "Events/GenericEvent")]
    public class GenericEvent : ScriptableObject
    {
        internal List<GenericEventListenerBase> listeners = new List<GenericEventListenerBase>();

        public virtual void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }
        }

        public virtual void RegisterListener(GenericEventListenerBase l)
        {
            if (!listeners.Contains(l))
                listeners.Add(l);
        }

        public virtual void UnregisterListener(GenericEventListenerBase l)
        {
            if (listeners.Contains(l))
                listeners.Remove(l);
        }
    }
}