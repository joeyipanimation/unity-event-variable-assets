using System;
using UnityEngine.Events;
using EventVariableAssets.Generics;

namespace EventVariableAssets
{
    [Serializable]
    public class IntResponseT0Event : UnityEvent<int>
    {
    }

    public class IntEventListener : GenericEventListenerBase
    {
        public IntResponseT0Event Response;

        public override void OnEventRaised()
        {
            Response.Invoke(((IntEvent)Event).Variable.Value);
        }
    }
}
