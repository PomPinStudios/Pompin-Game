using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class SaveData
{
    public List<int> goToAddId = new List<int>();
    public List<int> inventoryItemsAmount = new List<int>();
    public List<string> inventoryItemsName = new List<string>();

}
public class GameData : MonoBehaviour
{
    public SaveData saveData;
    public static GameData instance;
    public SaverController saver;

    private void Awake()
    {
        Debug.Log("SA DEPERTAO");
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(instance.gameObject);
            instance = this;
        }
        // Debug.Log(instance);   
        if (ShouldLoadInventary.shouldLoadInventory)
        {
            Time.timeScale = 1f;
            if (File.Exists(Application.persistentDataPath + "/playerInventory.dat"))
            {
                // Load();
                saver.CargarDatos();
            }
            else
            {
                // Save();
                saver.GuardarDatos();
            }
        }
        else
        {
            Time.timeScale = 1f;
            Save();
        }

    }

    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInventory.dat", FileMode.Create);

        SaveData data = new SaveData();
        data = saveData;

        formatter.Serialize(file, data);
        print("Data Saved");

        file.Close();
    }

    public void Load()
    {
        Debug.Log("LOAD");
        if (File.Exists(Application.persistentDataPath + "/playerInventory.dat"))
        {
            Debug.Log("SI QUE EXISTE");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInventory.dat", FileMode.Open);

            saveData = formatter.Deserialize(file) as SaveData;

            file.Close();
            // print("Data loaded");
        }
    }

    public void ClearData()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInventory.dat"))
        {
            File.Delete(Application.persistentDataPath + "/playerInventory.dat");
        }
    }

    public void ClearAllDataList()
    {
        saveData.goToAddId.Clear();
        saveData.inventoryItemsName.Clear();
        saveData.inventoryItemsAmount.Clear();
        Save();
    }

    public void DestroyInstance()
    {
        Destroy(instance.gameObject);
        instance = null;
    }
}
