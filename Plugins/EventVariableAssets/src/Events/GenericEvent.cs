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
        public virtual string Version { get => m_version; }

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
                    ClearCallStack();
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

                CallStackCounter++;

                // Formatting
                if (!string.IsNullOrEmpty(CallStackStrings))
                    CallStackStrings = "\n" + CallStackStrings;

                // Append callstack
                for (int i = stackTrace.FrameCount - 1; i >= 0 ; i--)
                {
                    StackFrame stackFrame = stackTrace.GetFrame(i);
                    string callingMethod = string.Format("({2}) {0}.{1}()"
                    , stackFrame.GetMethod().ReflectedType
                    , stackFrame.GetMethod().Name
                    , CallStackCounter
                    );
                    CallStackStrings = string.Format("{0}\n{1}", callingMethod, CallStackStrings);
                }
            }

            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }
        }

        public virtual void ClearCallStack()
        {
            CallStackStrings = string.Empty;
            CallStackCounter = 0;
        }

        public virtual bool UpgradeAsset()
        {
            if (m_version.Equals("0.0"))
            {
                m_version = "0.5";
                UpgradeAsset();
                return true;
            }
            else if (m_version.Equals("0.5"))
            {
                //Most up-to-date
                return false;
            }

            return false;
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