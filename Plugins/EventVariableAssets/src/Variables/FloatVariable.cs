using UnityEngine;
using EventVariableAssets.Generics;

namespace EventVariableAssets
{
    [CreateAssetMenu(fileName = "NewFloatVariable", menuName = "Variables/Float")]
    public class FloatVariable : GenericVariable<float>
    {
        public void SetValue(float value)
        {
            base.Value = value;
        }
    }
}