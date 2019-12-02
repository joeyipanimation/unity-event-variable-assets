using System.Collections.Generic;
using UnityEngine;
using EventVariableAssets.Generics;

namespace EventVariableAssets
{
    [CreateAssetMenu(fileName = "NewStringEvent", menuName = "Events/StringEvent")]
    public class StringEvent : GenericParamEvent<StringVariableReference>
    {
    }
}