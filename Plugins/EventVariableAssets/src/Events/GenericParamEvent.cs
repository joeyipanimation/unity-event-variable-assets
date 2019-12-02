using System.Collections.Generic;
using UnityEngine;

namespace EventVariableAssets.Generics
{
    //[CreateAssetMenu(fileName = "NewGenericParamEvent", menuName = "Events/GenericParamEvent")]
    public class GenericParamEvent<T> : GenericEvent where T : IGenericVariable
    {
        public T Variable;
    }
}