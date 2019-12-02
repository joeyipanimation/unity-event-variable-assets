using UnityEditor;
using EventVariableAssets.Generics;

namespace EventVariableAssets
{
    [CustomPropertyDrawer(typeof(IntVariableReference))]
    public class IntVariableReferenceEditor : GenericVariableReferenceEditor<int>
    {
    }
}