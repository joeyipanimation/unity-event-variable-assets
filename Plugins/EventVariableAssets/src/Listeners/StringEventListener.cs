using System;
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
        public StringResponseT0Event Response;

        public override void OnEventRaised()
        {
            Response.Invoke(((StringEvent)Event).Variable.Value);
        }
    }
}
