using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private string fileName;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F3))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            Load();
        }

    }


    private void Save()
    {
        SceneSerializer sceneSerializer = new SceneSerializer();
        List<SceneSerializer.SceneObjectState> allObjectState = sceneSerializer.Serialize();

        BinaryFormatter bf = new BinaryFormatter();

        Debug.Log(Application.persistentDataPath);

        FileStream file = File.Create(Application.persistentDataPath + "/" + fileName);

        bf.Serialize(file, allObjectState);
        file.Close();

        Debug.Log("Save!");
    }


    private void Load()
    {
        List<SceneSerializer.SceneObjectState> allObjectState = new List<SceneSerializer.SceneObjectState>();

        BinaryFormatter bf = new BinaryFormatter();

        if(File.Exists(Application.persistentDataPath + "/" + fileName) == false)
        {
            Debug.Log("File " + fileName + " not exist");
            return;
        }

        FileStream file = File.Open(Application.persistentDataPath + "/" + fileName, FileMode.Open);

        allObjectState = (List<SceneSerializer.SceneObjectState>) bf.Deserialize(file);
        file.Close();

        //Debug.Log(allObjectState.Count);


        SceneSerializer sceneSerializer = new SceneSerializer();
        sceneSerializer.Deserialize(allObjectState);

        Debug.Log("Load!");
    }

}
