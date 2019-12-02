using UnityEngine;
using EventVariableAssets.Generics;

namespace EventVariableAssets
{
    [CreateAssetMenu(fileName = "NewBoolVariable", menuName = "Variables/Bool")]
    public class BoolVariable : GenericVariable<bool>
    {
        public void SetValue(bool value)
        {
            base.Value = value;
        }
    }
}