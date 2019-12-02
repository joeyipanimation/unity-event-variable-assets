﻿using System;
using UnityEngine.Events;
using EventVariableAssets.Generics;

namespace EventVariableAssets
{
    [Serializable]
    public class BoolResponseT0Event : UnityEvent<bool>
    {
    }

    public class BoolEventListener : GenericEventListenerBase
    {
        public BoolResponseT0Event Response;

        public override void OnEventRaised()
        {
            Response.Invoke(((BoolEvent)Event).Variable.Value);
        }
    }
}
