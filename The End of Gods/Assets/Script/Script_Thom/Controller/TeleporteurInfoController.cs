using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class TeleporteurInfoController : MonoBehaviour {

    public static TeleporteurInfoController teleporteurInfoController;
    public Dictionary<string, bool> teleporterAcces;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (teleporteurInfoController == null)
        {

            try
            {
                LoadGame();
            }
            catch
            {
                SetDefaultValue();
            }

            teleporteurInfoController = this;
        }
        else if (teleporteurInfoController != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetDefaultValue()
    {
        teleporterAcces = TeleporterAccesManager.TeleporterAcces;
    }

    public void SaveGame()
    {
        FileStream file = File.Open(Application.persistentDataPath + "/teleporteurInfo.dat", FileMode.Create);
        TeleporteurData data = new TeleporteurData();
        data.teleporterAcces = TeleporterAccesManager.getTeleporterAccess();
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();

    }
    public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (!File.Exists(Application.persistentDataPath + "/teleporteurInfo.dat"))
        {
            throw new Exception("Game file does not exist");
        }
        FileStream file = File.Open(Application.persistentDataPath + "/teleporteurInfo.dat", FileMode.Open);
        TeleporteurData data = (TeleporteurData)(bf.Deserialize(file));
        TeleporterAccesManager.TeleporterAcces = data.teleporterAcces;
        
    }

}
[Serializable]
class TeleporteurData
{
    public Dictionary<string, bool> teleporterAcces;
}


