using System;
using UnityEngine;
using EventVariableAssets.Generics;

namespace EventVariableAssets
{
    public interface IGenericVariable
    {
        //object Value { get; set; }
    }

    public abstract class GenericVariable : ScriptableObject, IGenericVariable
    {
        public abstract object Value { get; set; }
        internal virtual object EditorValue { get; set; }
        public bool HasChanged { get; set; }

        //public static GenericVariable<T> GetAsType<T>(GenericVariable obj) where T : Type
        //{
        //    return (GenericVariable<T>)obj;
        //}

        //public abstract void SetValue<T>(T value) where T : Type

        public static GenericVariable GetAsType<T>(T baseType, GenericVariable obj) where T : Type
        {
            if      (baseType == typeof(float))     return (GenericVariable<float>)obj;
            else if (baseType == typeof(int))       return (GenericVariable<int>)obj;
            else if (baseType == typeof(string))    return (GenericVariable<string>)obj;
            else if (baseType == typeof(bool))      return (GenericVariable<bool>)obj;
            else return null;
        }
    }
}

namespace EventVariableAssets.Generics
{
    public class GenericVariable<T> : GenericVariable
    {
        [SerializeField] T m_value = default(T);
        //[HideInInspector][SerializeField] T m_runtimeValue = default(T);
        [SerializeField] T m_resetValue = default(T);
        //internal override object EditorValue
        //{
        //    get { return m_runtimeValue; }
        //    set { m_runtimeValue = (T)value; }
        //}
        public override object Value
        {
            //get { return (Application.isPlaying) ? RuntimeValue : m_value; }
            //set
            //{
            //    if (Application.isPlaying)
            //    {
            //        HasChanged = !value.Equals(m_runtimeValue);
            //        m_runtimeValue = (T)value;
            //    }
            //    else
            //    {
            //        HasChanged = !value.Equals(m_value);
            //        m_value = (T)value;
            //    }
            //}
            get { return m_value; }
            set { HasChanged = !value.Equals(m_value); m_value = (T)value; }
        }


        //public override void SetValue<L>(L value)
        //{
        //    throw new NotImplementedException();
        //}

        public static GenericVariable<T> GetAsType(GenericVariable obj)
        {
            return (GenericVariable<T>)obj;
        }

        //public static GenericVariable<T> GetAsTypedType<T>(T baseType, GenericVariable obj) where T : Type
        //{
        //    dynamic returnObj = null;
        //    if      (baseType == typeof(float))     returnObj = (FloatVariable)obj;
        //    else if (baseType == typeof(int))       returnObj = (IntVariable)obj;
        //    else if (baseType == typeof(string))    returnObj = (StringVariable)obj;
        //    else if (baseType == typeof(bool))      returnObj = (BoolVariable)obj;
        //    return returnObj;
        //}

        public void Reset()
        {
            if (m_resetValue != null)
            {
                Value = m_resetValue;
                //EditorValue = Value;
            }
        }
    }
}