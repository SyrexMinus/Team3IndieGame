using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class LoadNextLevel : MonoBehaviour
{
    public void SceneSwitcher()
    {
        if (SceneManager.GetActiveScene().buildIndex != 19)
        {
            Save(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Save(5);
            SceneManager.LoadScene(5);
        }
    }
    // saving and loading game
    public static int lastLevel;

    void Start()
    {
        Load();
    }

    //методы загрузки и сохранения статические, поэтому их можно вызвать откуда угодно
    public static void Save(int levelIndex)
    {
        lastLevel = levelIndex;
        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath это строка; выведите ее в логах и вы увидите расположение файла сохранений
        FileStream file = File.Create(Application.persistentDataPath + "/lastLevel.save");
        bf.Serialize(file, lastLevel);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/lastLevel.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/lastLevel.save", FileMode.Open);
            lastLevel = (int)bf.Deserialize(file);
            file.Close();
        }
        if (lastLevel != SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene(lastLevel);
        }
    }
}
