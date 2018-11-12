using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;


public class ShopInfoController : MonoBehaviour {

    public static ShopInfoController shopInfoController;

    public int healthPrice = 0;
    public int defencePrice = 500;
    public int attackPrice = 500;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (shopInfoController == null)
        {

            try
            {
                LoadGame();
            }
            catch
            {
                SetDefaultValue();
            }

            shopInfoController = this;
        }
        else if (shopInfoController != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetDefaultValue()
    {
        healthPrice = ShopInfo.HealthPrice;
        defencePrice = ShopInfo.DefencePrice;
        attackPrice = ShopInfo.AttackPrice;
    }

    public void SaveGame()
    {
        FileStream file = File.Open(Application.persistentDataPath + "/shopInfo.dat", FileMode.Create);
        ShopData data = new ShopData();
        data.healthPrice = ShopInfo.HealthPrice;
        data.attackPrice = ShopInfo.AttackPrice;
        data.defencePrice = ShopInfo.DefencePrice;
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();

    }
    public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (!File.Exists(Application.persistentDataPath + "/shopInfo.dat"))
        {
            throw new Exception("Game file does not exist");
        }
        FileStream file = File.Open(Application.persistentDataPath + "/shopInfo.dat", FileMode.Open);
        ShopData data = (ShopData)(bf.Deserialize(file));
        ShopInfo.HealthPrice = data.healthPrice;
        ShopInfo.AttackPrice = data.attackPrice;
        ShopInfo.DefencePrice = data.defencePrice;
       
    }


}
[Serializable]
class ShopData
{
    public int healthPrice;
    public int attackPrice;
    public int defencePrice;

}


