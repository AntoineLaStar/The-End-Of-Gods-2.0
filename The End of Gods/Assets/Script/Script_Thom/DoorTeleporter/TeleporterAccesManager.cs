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
        true,
        false
    };
    public static Dictionary<string, bool> TeleporterAcces
    {
        get { return teleporterAcces; }
        set { teleporterAcces = value; isInitialize = true; }
    }


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

    public static void unlockTeleporteur(string teleporterName)
    {

        teleporterAcces[teleporterName] = true;

    }

    public static bool GetAccess(string teleporterName)

    {
        if (isInitialize == false)
        {
            InitializeDictionary();
        }
        return teleporterAcces[teleporterName];
    }


    public static bool getIsInitialize()
    {
        return isInitialize;
    }
    public static Dictionary<string, bool> getTeleporterAccess(){

        if(!isInitialize){
            InitializeDictionary();

        }
        return teleporterAcces;
    }
    public static void lockAllTeleporter()
    {
        for(int i= 0; i < telepoterName.Length; i++)
        {
            teleporterAcces[telepoterName[i]] = false;
        }
    }


}
