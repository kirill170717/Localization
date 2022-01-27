using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class ListToPopupAttribute : PropertyAttribute
{
    public Type myType;
    public string propertyName;

    public ListToPopupAttribute(Type _myType, string _propertyName)
    {
        myType = _myType;
        propertyName = _propertyName;
    }
}

[CustomPropertyDrawer(typeof(ListToPopupAttribute))]
public class ListToPopupDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ListToPopupAttribute atb = attribute as ListToPopupAttribute;
        List<string> stringList = null;

        if (atb.myType.GetField(atb.propertyName.ToString()) != null)
        {
            stringList = atb.myType.GetField(atb.propertyName.ToString()).GetValue(atb.myType) as List<string>;
        }

        if (stringList != null && stringList.Count != 0)
        {
            int selectedIndex = Mathf.Max(stringList.IndexOf(property.stringValue), 0);
            selectedIndex = EditorGUI.Popup(position, property.name, selectedIndex, stringList.ToArray());
            property.stringValue = stringList[selectedIndex].ToString();
        }
        else
            EditorGUI.PropertyField(position, property, label);
    }
}
public class PopupTest : MonoBehaviour
{
    [SerializeField]
    public static List<SystemLanguage> languages;
    [ListToPopup(typeof(PopupTest), "languages")]
    public string Popup;

    [ContextMenu("Create number list")]
    public void CreateNumberList()
    {
        languages = new List<SystemLanguage> {SystemLanguage.English, SystemLanguage.Russian, SystemLanguage.German};
    }
}