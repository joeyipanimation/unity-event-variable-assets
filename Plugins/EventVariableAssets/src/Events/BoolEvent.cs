using System.Collections.Generic;
using UnityEngine;
using EventVariableAssets.Generics;

namespace EventVariableAssets
{
    [CreateAssetMenu(fileName = "NewBoolEvent", menuName = "Events/BoolEvent")]
    public class BoolEvent : GenericParamEvent<BoolVariableReference>
    {
    }
}
