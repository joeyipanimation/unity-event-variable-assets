using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace EventVariableAssets
{
    [CreateAssetMenu(fileName = "NewGenericEvent", menuName = "Events/GenericEvent")]
    public class GenericEvent : ScriptableObject
    {
        [HideInInspector][SerializeField] string m_version = String.Empty; //Set in constructor
        internal List<GenericEventListenerBase> listeners = new List<GenericEventListenerBase>();

        bool m_traceCallStack = false;
        public bool TraceCallStack
        {
            get
            {
                return m_traceCallStack;
            }
            set
            {
                m_traceCallStack = value;
                if (!value)
                {
                    CallStackStrings = string.Empty;
                    CallStackCounter = 0;
                }
            }
        }
        public string CallStackStrings { get; set; }
        int CallStackCounter = 0;

        public GenericEvent()
        {
            m_version = Globals.Version;
        }

        public virtual void Raise()
        {
            if (TraceCallStack)
            {
                StackTrace stackTrace = new StackTrace();
                StackFrame stackFrame = stackTrace.GetFrame(1);
                CallStackCounter++;
                string callingMethod = string.Format("({2}) {0}.{1}()", stackFrame.GetMethod().ReflectedType, stackFrame.GetMethod().Name, CallStackCounter);
                CallStackStrings = string.Format("{0}\n{1}", callingMethod, CallStackStrings);
                UnityEngine.Debug.Log(callingMethod, this);
            }

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