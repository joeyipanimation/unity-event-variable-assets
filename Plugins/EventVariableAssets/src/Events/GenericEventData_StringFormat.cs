using System;
using System.Reflection;
using UnityEngine;

namespace EventVariableAssets
{
    /// <summary>
    /// This container enables much less specialized code to do simple function like applying a value to a field.
    /// </summary>
    [Serializable]
    public class GenericEventData_StringFormat : MonoBehaviour
    {
        public ComponentProperty PropertyObject;
        public StringVariableReference StringFormat;
        public GenericVariable[] Variables;

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
            string valueString = string.Empty;
            if (StringFormat == null && Variables.Length > 0)
                valueString = Variables[0].Value.ToString();
            else if (StringFormat == null && Variables.Length == 0)
            { } //Do nothing
            else if (string.IsNullOrEmpty(StringFormat.Value) && Variables.Length > 0)
                valueString = Variables[0].Value.ToString();
            else if (string.IsNullOrEmpty(StringFormat.Value) && Variables.Length == 0)
            { } //Do nothing
            else if (Variables.Length == 0)
                valueString = StringFormat.Value;

            //Check for mis-matched number of arguments
            else
            {
                try
                {
                    string[] values = new string[Variables.Length];
                    for (int i = 0; i < Variables.Length; i++)
                    {
                        values[i] = Variables[i].Value.ToString();
                    }

                    valueString = string.Format(StringFormat.Value, values);
                }
                catch
                {
                    valueString = string.Format(StringFormat.Value);
                }
            }
            p.SetValue(PropertyObject.ComponentObject, valueString, null);
        }
    }
}