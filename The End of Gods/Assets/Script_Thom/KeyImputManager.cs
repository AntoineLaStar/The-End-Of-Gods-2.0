using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class KeyImputManager
{
    static Dictionary<string, KeyCode> keyMapping;
    static Dictionary<string, KeyCode> defaultKeyMapping;
    static bool keyMapHaveChange = false;
    static bool isInitialize = false;
    static string[] keyMaps = new string[]
    {
        "Attack",
        "Left",
        "Right",
        "DashLeft",
        "DashRight",
        "Jump",
        "interact"
    };
    static KeyCode[] defaults = new KeyCode[]
    {
        
        KeyCode.LeftShift,
        KeyCode.A,
        KeyCode.D,
        KeyCode.Q,
        KeyCode.E,
        KeyCode.Space,
        KeyCode.F
    };

    public static void KeyInputManager()
    {
        
        InitializeDictionary();
    }

    private static void InitializeDictionary()
    {
        
        keyMapping = new Dictionary<string, KeyCode>();
        for (int i = 0; i < keyMaps.Length; ++i)
        {
            keyMapping.Add(keyMaps[i], defaults[i]);
        }
        isInitialize = true;
    }

    public static void SetKeyMap(string keyMap, KeyCode key)
    {
        if (!keyMapping.ContainsKey(keyMap))
        {
            throw new ArgumentException("Invalid KeyMap in SetKeyMap: " + keyMap);
        }
        else
        {
            keyMapping[keyMap] = key;
        }


    }
    public static string GetKeyBind(string keyMap)

    {
        return keyMapping[keyMap].ToString();
    }

    public static bool GetKeyDown(string keyMap)
    {
        return Input.GetKeyDown(keyMapping[keyMap]);
    }
    public static void SaveActualKeyMapping()
    {
        defaultKeyMapping = keyMapping;
    }
    public static bool getKeyMapHasChange()
    {
        return keyMapHaveChange;
    }
    public static void changeKeyMapHaveChange()
    {
        keyMapHaveChange = !keyMapHaveChange;
    } 
    public static bool getIsInitialize()
    {
        return isInitialize;
    }
 
}
