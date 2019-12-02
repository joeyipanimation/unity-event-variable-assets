using UnityEditor;
using EventVariableAssets.Generics;

namespace EventVariableAssets
{
    [CustomPropertyDrawer(typeof(FloatVariableReference))]
    public class FloatVariableReferenceEditor : GenericVariableReferenceEditor<float>
    {
    }
}