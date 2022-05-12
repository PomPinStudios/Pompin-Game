using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    public static void SavePlayerData(TopDownController player, PlayerStats stats, DayTimeController DTcontroller )
    {
        PlayerData playerData = new PlayerData(player, stats, DTcontroller);

        string dataPath = Application.persistentDataPath+ "/player.save";
        FileStream fileStream = new FileStream ( dataPath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, playerData);
        fileStream.Close();
    }

    public static PlayerData LoadPlayerData()
    {
        string dataPath = Application.persistentDataPath+ "/player.save";

        if( File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            PlayerData playerData = (PlayerData) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return playerData;
        }else
        {
            Debug.LogError("No se encontro el archivo de guardado");
            return null;
        }
    }
}
