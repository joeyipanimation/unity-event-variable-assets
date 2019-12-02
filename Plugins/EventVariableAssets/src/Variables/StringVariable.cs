using UnityEngine;
using EventVariableAssets.Generics;

namespace EventVariableAssets
{
    [CreateAssetMenu(fileName = "NewStringVariable", menuName = "Variables/String")]
    public class StringVariable : GenericVariable<string>
    {
        public void SetValue(string value)
        {
            base.Value = value;
        }
    }
}