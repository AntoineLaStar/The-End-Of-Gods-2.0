using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterAccesManager : MonoBehaviour {
    static Dictionary<string, bool> teleporterAcces;
    static bool isInitialize = false;
    static string[] telepoterName = new string[]
     {
        "tpBlack",
        "tpMauve",
        "tpBleu"
     };
    static bool[] defaultAcces = new bool[]
    {
        false,
        false,
        false
    };

    public static void teleporterAccesManager()
    {

        InitializeDictionary();
    }

    private static void InitializeDictionary()
    {

        teleporterAcces = new Dictionary<string, bool>();
        for (int i = 0; i < telepoterName.Length; ++i)
        {
            teleporterAcces.Add(telepoterName[i], defaultAcces[i]);
        }
        isInitialize = true;
    }

    public static void SetKeyMap(string teleporterName, bool access)
    {
        teleporterAcces[teleporterName] = access;

    }

    public static bool GetAccess(string teleporterName)

    {
        return teleporterAcces[teleporterName];
    }


    public static bool getIsInitialize()
    {
        return isInitialize;
    }

}
