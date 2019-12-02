using System;
using System.Reflection;
using UnityEngine;

namespace EventVariableAssets
{
    /// <summary>
    /// This container enables much less specialized code to do simple function like applying a value to a field.
    /// </summary>
    [Serializable]
    public class GenericEventData : MonoBehaviour
    {
        public ComponentProperty PropertyObject;
        public GenericVariable Variable;

        public void ApplyDataToProperty()
        {
            PropertyInfo p = PropertyObject.ComponentObject.GetType().GetProperty(PropertyObject.PropertyName);
            Type pT = p.PropertyType;

            //Early exit
            if (PropertyObject.ComponentObject == null || string.IsNullOrEmpty(PropertyObject.PropertyName))
            {
                return;
            }

            //Defaults
            if (Variable == null)
            {
                if (pT == typeof(string))
                    p.SetValue(PropertyObject.ComponentObject, default(string), null);
                else if (pT == typeof(int))
                    p.SetValue(PropertyObject.ComponentObject, default(int), null);
                else if (pT == typeof(float))
                    p.SetValue(PropertyObject.ComponentObject, default(float), null);
                else if (pT == typeof(bool))
                    p.SetValue(PropertyObject.ComponentObject, default(bool), null);
                return;
            }

            string valueString = Variable.Value.ToString();
            if (pT == typeof(string))
            {
                p.SetValue(PropertyObject.ComponentObject, valueString, null);
            }
            else if (pT == typeof(int))
            {
                int intValue;
                bool success = int.TryParse(valueString, out intValue);
                if (success)
                    p.SetValue(PropertyObject.ComponentObject, intValue, null);
                else
                    Debug.LogWarningFormat(this, "Variable type ({0}) and property type ({1}) do not match.", Variable.GetType(), pT);
            }
            else if (pT == typeof(float))
            {
                float floatValue;
                bool success = float.TryParse(valueString, out floatValue);
                if (success)
                    p.SetValue(PropertyObject.ComponentObject, floatValue, null);
                else
                    Debug.LogWarningFormat(this, "Variable type ({0}) and property type ({1}) do not match.", Variable.GetType(), pT);
            }
            else if (pT == typeof(bool))
            {
                bool boolValue;
                bool success = bool.TryParse(valueString, out boolValue);
                if (success)
                    p.SetValue(PropertyObject.ComponentObject, boolValue, null);
                else
                    Debug.LogWarningFormat(this, "Variable type ({0}) and property type ({1}) do not match.", Variable.GetType(), pT);
            }
            else
            {
                Debug.LogWarningFormat(this, "Type ({0}) of property ({0}) is not implemented", pT, p.Name);
            }

            //foreach (var p in ComponentPropertyObject.ComponentObject.GetType().GetProperties())
            //{
            //    Debug.LogWarning(p);
            //}
        }
    }
}