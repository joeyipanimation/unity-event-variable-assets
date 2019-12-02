using System;
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

        public override void OnEventRaised()
        {
            Response.Invoke(((FloatEvent)Event).Variable.Value);
        }
    }
}
