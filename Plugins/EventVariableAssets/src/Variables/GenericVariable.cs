using System;
using UnityEngine;
using EventVariableAssets.Generics;

namespace EventVariableAssets
{
    public interface IGenericVariable
    {
    }

    public abstract class GenericVariable : ScriptableObject, IGenericVariable
    {
        public abstract string Version { get; }
        public abstract object Value { get; set; }
        public abstract object RuntimeValue { get; }
        public bool HasChanged { get; set; }

      
        public static GenericVariable GetAsType<T>(T baseType, GenericVariable obj) where T : Type
        {
            if      (baseType == typeof(float))     return (GenericVariable<float>)obj;
            else if (baseType == typeof(int))       return (GenericVariable<int>)obj;
            else if (baseType == typeof(string))    return (GenericVariable<string>)obj;
            else if (baseType == typeof(bool))      return (GenericVariable<bool>)obj;
            else return null;
        }

        public static Type GetBaseType(GenericVariable obj)
        {
            if      (obj.GetType().Equals(typeof(FloatVariable)))   return typeof(float);
            else if (obj.GetType().Equals(typeof(IntVariable)))     return typeof(int);
            else if (obj.GetType().Equals(typeof(StringVariable)))  return typeof(string);
            else if (obj.GetType().Equals(typeof(BoolVariable)))    return typeof(bool);
            else return null;
        }
    }
}

namespace EventVariableAssets.Generics
{
    public class GenericVariable<T> : GenericVariable
    {
        [HideInInspector][SerializeField] string m_version = String.Empty; //Set in constructor
        [HideInInspector][SerializeField] T m_value = default(T);
        [HideInInspector][SerializeField] T m_runtimeValue = default(T);
        [SerializeField] T m_resetValue = default(T);

        public GenericVariable()
        {
            m_version = Globals.Version;
        }

        #region Properties
        public override string Version { get => m_version; }

        public override object Value
        {
            get { return (Application.isPlaying) ? RuntimeValue : m_value; }
            set
            {
                if (Application.isPlaying)
                {
                    HasChanged = !value.Equals(RuntimeValue);
                    m_runtimeValue = (T)value;
                }
                else
                {
                    HasChanged = !value.Equals(m_value);
                    m_runtimeValue = (T)value;
                    m_value = (T)value;
                }
            }
            //get { return m_value; }
            //set { HasChanged = !value.Equals(m_value); m_value = (T)value; }
        }

        public override object RuntimeValue
        {
            get { return m_runtimeValue; }
        }
        #endregion

        public static GenericVariable<T> GetAsType(GenericVariable obj)
        {
            return (GenericVariable<T>)obj;
        }

        public void Reset()
        {
            try
            {
                Value = m_resetValue;
            }
            catch
            {
            }
        }
    }
}