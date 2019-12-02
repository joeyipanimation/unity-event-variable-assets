using System;
using UnityEngine;
using UnityEditor;

namespace EventVariableAssets.Generics
{
    [CustomPropertyDrawer(typeof(Type), useForChildren: true)]
    public class GenericVariableReferenceEditor<T> : PropertyDrawer
    {
        struct MenuObject
        {
            public SerializedProperty property;
            public string propertyName;
            public int intValue;
            public bool boolValue;
            //Add other basic variable types (float, string)

            public MenuObject(SerializedProperty p, string n, int iv, bool bv)
            {
                property = p;
                propertyName = n;
                intValue = iv;
                boolValue = bv;
            }
        }

        string PARAM_USECONSTANTBOOL = "m_useConstant";
        string PARAM_CONSTANTVALUE = "ConstantValue";
        string PARAM_VARIABLE = "Variable";
        string useConstantLabel = "Use Constant";
        string useVariableLabelFormat = "Use Variable ({0})";
        GUIStyle dropdownStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (dropdownStyle == null)
            {
                dropdownStyle = GUI.skin.FindStyle("PaneOptions");
                dropdownStyle.imagePosition = ImagePosition.ImageOnly;
            }

            //Create string to show variable asset's value
            bool useConstant = property.FindPropertyRelative(PARAM_USECONSTANTBOOL).boolValue;
            GenericVariable varObj = (GenericVariable)property.FindPropertyRelative(PARAM_VARIABLE).objectReferenceValue;
            string valueString = "--";
            if (varObj != null)
            {
                if (varObj.Value != null)
                {
                    valueString = varObj.Value.ToString();
                }
            }
            string useVariableLabel = string.Format(useVariableLabelFormat, valueString);

            //Using BeginProperty / EndProperty on the parent property means that prefab override logic works on the entire property.
            EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0; //Don't make child fields be indented

            //Field sizes
            float dropdownWidth = 20;
            Rect valueRect = new Rect(position.x + dropdownWidth, position.y, position.width - dropdownWidth, position.height);
            Rect dropdownRect = new Rect(position.x, position.y, dropdownWidth, position.height);
            dropdownRect.yMin += dropdownStyle.margin.top;
            dropdownRect.width = dropdownStyle.fixedWidth + dropdownStyle.margin.right;
            position.xMin = dropdownRect.xMax;

            //Draw dropdown
            if (EditorGUI.DropdownButton(dropdownRect, new GUIContent(), FocusType.Passive, dropdownStyle))
            {
                //Create generic menu
                GenericMenu menu = new GenericMenu();
                AddMenuItem(menu, useConstantLabel, new MenuObject(property, PARAM_USECONSTANTBOOL, 0, true));
                AddMenuItem(menu, useVariableLabel, new MenuObject(property, PARAM_USECONSTANTBOOL, 0, false));
                menu.ShowAsContext();
            }

            //Draw fields based on dropdown value
            if (useConstant)
            {
                SerializedProperty sp = property.FindPropertyRelative(PARAM_CONSTANTVALUE);
                if (sp.propertyType == SerializedPropertyType.Float)
                    sp.floatValue = EditorGUI.FloatField(valueRect, sp.floatValue);
                else if (sp.propertyType == SerializedPropertyType.Integer)
                    sp.intValue = EditorGUI.IntField(valueRect, sp.intValue);
                else if (sp.propertyType == SerializedPropertyType.String)
                    sp.stringValue = EditorGUI.TextField(valueRect, sp.stringValue);
                else if (sp.propertyType == SerializedPropertyType.Boolean)
                    sp.boolValue = EditorGUI.Toggle(valueRect, sp.boolValue);
                else
                    Debug.LogWarning("Unimplemented constant variable type: " + sp.propertyType.ToString());

            }
            else
                EditorGUI.PropertyField(valueRect, property.FindPropertyRelative(PARAM_VARIABLE), GUIContent.none);

            //Reset indent
            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }

        void AddMenuItem(GenericMenu menu, string menuPath, MenuObject menuObj)
        {
            //Menu item is marked as selected if it matches the current value
            bool isCurrent = menuObj.property.FindPropertyRelative(menuObj.propertyName).boolValue == menuObj.boolValue;
            menu.AddItem(new GUIContent(menuPath), isCurrent, OnItemSelected, menuObj);
        }

        /// <summary>
        /// GenericMenu event handler for when a menu item is selected
        /// </summary>
        /// <param name="menuObj"></param>
        void OnItemSelected(object menuObj)
        {
            MenuObject obj = (MenuObject)menuObj;
            obj.property.FindPropertyRelative(obj.propertyName).boolValue = obj.boolValue;
            obj.property.serializedObject.ApplyModifiedProperties();
        }
    }
}