using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;


public  class PlayerInfoController : MonoBehaviour {

	public static PlayerInfoController playerInfoController;

    public int health;
    public int attack;
    public float defense;
    public int money;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (playerInfoController == null)
        {

            try
            {
                LoadGame();
            }
            catch
            {
                SetDefaultValue();
            }

            playerInfoController = this;
        }
        else if (playerInfoController != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetDefaultValue()
    {
        attack = Player_Info.degat;
        defense = Player_Info.defence;
        health = Player_Info.startingHealth;
        money = Player_Info.money;
    }

    public  void SaveGame()
    {
        FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Create);
        PlayerData data = new PlayerData();
        data.health = Player_Info.startingHealth;
        data.attack = Player_Info.degat;
        data.defence = Player_Info.defence;
        data.money = Player_Info.money;
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();

    }
    public  void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (!File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            throw new Exception("Game file does not exist");
        }
        FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
        PlayerData data = (PlayerData)(bf.Deserialize(file));
        Player_Info.startingHealth = data.health;
        Player_Info.degat = data.attack;
        Player_Info.defence = data.defence;
        Player_Info.money = data.money;
    }


}
[Serializable]
class PlayerData
{
    public int health;
    public int attack;
    public float defence;
    public int money;
}
