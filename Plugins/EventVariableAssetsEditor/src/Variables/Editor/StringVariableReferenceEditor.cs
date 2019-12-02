using UnityEditor;
using EventVariableAssets.Generics;

namespace EventVariableAssets
{
    [CustomPropertyDrawer(typeof(StringVariableReference))]
    public class StringVariableReferenceEditor : GenericVariableReferenceEditor<string>
    {
    }
}