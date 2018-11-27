using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public static class KeyImputManager
{
    static Dictionary<string, KeyCode> keyMapping;
    static Dictionary<string, KeyCode> defaultKeyMapping;
    static bool keyMapHaveChange = false;
    static bool isInitialize = false;
    static bool mouvementLock = false;
    static string[] keyMaps = new string[]
    {
        "Attack",
        "Left",
        "Right",
        "DashLeft",
        "DashRight",
        "Jump",
        "interact",
        "Defence",
        "Pause"
    };
    static KeyCode[] defaults = new KeyCode[]
    {

        KeyCode.LeftShift,
        KeyCode.A,
        KeyCode.D,
        KeyCode.Q,
        KeyCode.E,
        KeyCode.Space,
        KeyCode.F,
        KeyCode.C,
        KeyCode.P
    };

    public static Dictionary<string, KeyCode> KeyMapping
    {
        get { return keyMapping; }
        set { keyMapping = value; isInitialize = true; }
    }

    public static Dictionary<string, KeyCode> DefaultKeyMapping
    {
        get { return defaultKeyMapping; }
        set { defaultKeyMapping = value; }
    }

    public static void KeyInputManager()
    {
        if (!isInitialize){
            InitializeDictionary();
            freePlayerMouvement();
        
        }
       
    }

    private static void InitializeDictionary()
    {
        try
        {
            keyMapping = new Dictionary<string, KeyCode>();
            for (int i = 0; i < keyMaps.Length; ++i)
            {
                keyMapping.Add(keyMaps[i], defaults[i]);
            }
            isInitialize = true;
            ControlController.controlController.SaveGame();
        }
        catch
        {

        }


    }

    public static void SetKeyMap(string keyMap, KeyCode key)
    {
        if (!keyMapping.ContainsKey(keyMap))
        {
            throw new ArgumentException("Invalid KeyMap in SetKeyMap: " + keyMap);
        }
        else
        {
            checkIfKeyIsUsed(key);

            keyMapping[keyMap] = key;
            ControlController.controlController.SaveGame();
        }


    }

    private static void checkIfKeyIsUsed(KeyCode key)
    {
        for (int index = 0; index < keyMapping.Count; index++)
        {
            string keyBind = keyMapping.ElementAt(index).Key;
            KeyCode theKey = keyMapping.ElementAt(index).Value;
            if (keyMapping[keyBind] == key)
            {
                keyMapping[keyBind] = KeyCode.None;
            }
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
    public static void resetKeyBind()
    {
        keyMapHaveChange = true;
        InitializeDictionary();

    }

    public static void changeLockState()
    {
        mouvementLock = !mouvementLock;
    }
    public static void freePlayerMouvement()
    {
        mouvementLock = false;
    }
    public static void LockPlayerMouvement()
    {
        mouvementLock = true;
    }
    public static bool getMouvementLock()
    {
        return mouvementLock;
    }
   
}
