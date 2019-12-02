using System;
using UnityEngine;
using UnityEngine.Events;
using EventVariableAssets.Generics;

namespace EventVariableAssets
{
    [Serializable]
    public class StringResponseT0Event : UnityEvent<string>
    {
    }

    public class StringEventListener : GenericEventListenerBase
    {
        public StringVariableReference StringFormat;
        public StringResponseT0Event Response;

        public override void OnEventRaised()
        {
            //Cast event values to string
            string eventValue = string.Empty;
            if      (Event.GetType().Equals(typeof(StringEvent)))
                eventValue = ((StringEvent)Event).Variable.Value;
            else if (Event.GetType().Equals(typeof(BoolEvent)))
                eventValue = ((BoolEvent)Event).Variable.Value ? "true" : "false";
            else if (Event.GetType().Equals(typeof(IntEvent)))
                eventValue = ((IntEvent)Event).Variable.Value.ToString();
            else if (Event.GetType().Equals(typeof(FloatEvent)))
                eventValue = ((FloatEvent)Event).Variable.Value.ToString();
            else
                Debug.LogError("Cannot cast event value to string. Event type must be one of default types (string, bool, int, float) for type-casting to work.", this);

            if (StringFormat != null)
            {
                Response.Invoke(string.Format(StringFormat.Value, eventValue));
            }
            else if (string.IsNullOrEmpty(StringFormat.Value))
            {
                Response.Invoke(eventValue);
            }
            else
            {
                Response.Invoke(eventValue);
            }
        }
    }
}
