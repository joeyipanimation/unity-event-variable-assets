using System.Collections.Generic;
using UnityEngine;

namespace EventVariableAssets.Generics
{
    public class GenericParamEvent<T> : GenericEvent where T : IGenericVariable
    {
        public T Variable;
    }
}