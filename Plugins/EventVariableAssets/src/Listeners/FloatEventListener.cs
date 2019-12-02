using System;
using UnityEngine;
using UnityEngine.Events;
using EventVariableAssets.Generics;

namespace EventVariableAssets
{
    [Serializable]
    public class FloatResponseT0Event : UnityEvent<float>
    {
    }

    public class FloatEventListener : GenericEventListenerBase
    {
        public FloatResponseT0Event Response;

        [Tooltip("Total value and its response are used in conjunction for the 'reversed' effect. For example, if TotalValue=1.0 and the event's value=0.85, then a value of (1.0-0.85) is passed to TotalValueMinusResponse")]
        public FloatVariableReference TotalValue;
        public FloatResponseT0Event TotalValueMinusResponse;

        public override void OnEventRaised()
        {
            Response.Invoke(((FloatEvent)Event).Variable.Value);
            TotalValueMinusResponse.Invoke(TotalValue.Value - ((FloatEvent)Event).Variable.Value);
        }
    }
}
