using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class ControlController : MonoBehaviour {

    public static ControlController controlController;

    public Dictionary<string, KeyCode> keyMapping;
 

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (controlController == null)
        {

            try
            {
                LoadGame();
            }
            catch
            {
                SetDefaultValue();
            }

            controlController = this;
        }
        else if (controlController != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetDefaultValue()
    {
        keyMapping = KeyImputManager.DefaultKeyMapping;
  
    }

    public void SaveGame()
    {
        FileStream file = File.Open(Application.persistentDataPath + "/controlInfo.dat", FileMode.Create);
        ConntrolData data = new ConntrolData();
        data.keyMapping = KeyImputManager.KeyMapping;
   
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();

    }
    public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (!File.Exists(Application.persistentDataPath + "/controlInfo.dat"))
        {
            throw new Exception("Game file does not exist");
        }
        FileStream file = File.Open(Application.persistentDataPath + "/controlInfo.dat", FileMode.Open);
        ConntrolData data = (ConntrolData)(bf.Deserialize(file));
        KeyImputManager.KeyMapping = data.keyMapping;
  

    }


}
[Serializable]
class ConntrolData
{
    public Dictionary<string, KeyCode> keyMapping;


}

