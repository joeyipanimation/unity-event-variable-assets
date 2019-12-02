using UnityEngine;
using EventVariableAssets.Generics;

namespace EventVariableAssets
{
    [CreateAssetMenu(fileName = "NewIntVariable", menuName = "Variables/Int")]
    public class IntVariable : GenericVariable<int>
    {
        public void SetValue(int value)
        {
            base.Value = value;
        }
    }
}