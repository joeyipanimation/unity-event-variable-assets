using System.Collections.Generic;
using UnityEngine;
using EventVariableAssets.Generics;

namespace EventVariableAssets
{
    [CreateAssetMenu(fileName = "NewFloatEvent", menuName = "Events/FloatEvent")]
    public class FloatEvent : GenericParamEvent<FloatVariableReference>
    {
    }
}
