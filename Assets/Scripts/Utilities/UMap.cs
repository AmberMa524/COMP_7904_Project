using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// See "AudioManager.cs" for documentation.

[Serializable]
public class UMap<T>
{
    public List<UMap_Object<T>> data;

    public UMap()
    {
        data = new();
    }

    public T this[string key]
    {
        get { return data.Find(k => k.key.Equals(key)).value; }
    }

    public void Add(string key, T value)
    {
        if (data.Exists(k => k.key.Equals(key))) return;

        data.Add(new(key, value));
    }
}

[Serializable]
public class UMap_Object<T>
{
    public string key;
    public T value;

    public UMap_Object(string key, T value)
    {
        this.key = key;
        this.value = value;
    }
}

[CustomPropertyDrawer(typeof(UMap_Object<>))]
public class UMap_ObjectDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty keyProperty = property.FindPropertyRelative("key");
        SerializedProperty valueProperty = property.FindPropertyRelative("value");

        position.height = EditorGUIUtility.singleLineHeight;

        float keyWidth = position.width * 0.4f;
        float valueWidth = position.width * 0.6f;
        float margin = 2.0f;

        Rect keyRect = new Rect(position.x, position.y, keyWidth, position.height);
        Rect valueRect = new Rect(position.x + keyWidth + margin, position.y, valueWidth, position.height);

        EditorGUI.PropertyField(keyRect, keyProperty, GUIContent.none);
        EditorGUI.PropertyField(valueRect, valueProperty, GUIContent.none);
    }
}