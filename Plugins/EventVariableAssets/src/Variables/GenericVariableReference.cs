using System;
using UnityEngine;

namespace EventVariableAssets.Generics
{
    [Serializable]
    public class GenericVariableReference<T> : IGenericVariable
    {
        [HideInInspector]
        [SerializeField]
        bool m_useConstant = false;
        public bool UseConstant { get { return m_useConstant; } set { m_hasChanged = (m_useConstant == value); m_useConstant = value; } }
        public T ConstantValue;
        public GenericVariable Variable;

        public T Value
        {
            get { return UseConstant ? ConstantValue : GetValueFromReference(); }
            set
            {
                if (UseConstant)
                {
                    ConstantValue = value;
                }
                else
                {
                    SetValueOfReference(value);
                }
            }
        }

        T GetValueFromReference()
        {
            GenericVariable<T> refObj = GenericVariable<T>.GetAsType(Variable);
            if (refObj != null)
                //if (refObj.Value)
                try
                {
                    return (T)refObj.Value;
                }
                catch
                {
                    return default(T);
                }
                    
            else
                return default(T);
        }

        void SetValueOfReference(T value)
        {
            GenericVariable<T> refObj = GenericVariable<T>.GetAsType(Variable);
            if (refObj != null)
                refObj.Value = value;
        }

        bool m_hasChanged;
        public bool HasChanged
        {
            get { return ((m_hasChanged) || (GenericVariable<T>.GetAsType(Variable).HasChanged)); }
        }
    }
}