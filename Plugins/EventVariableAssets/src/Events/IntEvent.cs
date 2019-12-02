using System.Collections.Generic;
using UnityEngine;
using EventVariableAssets.Generics;

namespace EventVariableAssets
{
    [CreateAssetMenu(fileName = "NewIntEvent", menuName = "Events/IntEvent")]
    public class IntEvent : GenericParamEvent<IntVariableReference>
    {
    }
}