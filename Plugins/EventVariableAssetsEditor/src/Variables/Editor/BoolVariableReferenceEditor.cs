using UnityEditor;
using EventVariableAssets.Generics;

namespace EventVariableAssets
{
    [CustomPropertyDrawer(typeof(BoolVariableReference))]
    public class BoolVariableReferenceEditor : GenericVariableReferenceEditor<bool>
    {
    }
}