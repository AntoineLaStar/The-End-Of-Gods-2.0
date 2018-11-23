

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class StartGame : MonoBehaviour
{

    public void LoadScene()
    {

        SceneManager.LoadScene("Scenes/Hell");
    }

    public void newGame()
    {
        File.Delete(Application.persistentDataPath + "/gameInfo.dat");
        File.Delete(Application.persistentDataPath + "/shopInfo.dat");
        File.Delete(Application.persistentDataPath + "/teleporteurInfo.dat");
    }
}
