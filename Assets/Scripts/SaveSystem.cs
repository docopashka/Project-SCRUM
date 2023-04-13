using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem{
      
    [System.Serializable]
    public class SaveData 
    {
        public Vector3 playerPosition;
    }

    public static void SaveGame(Transform playerTransform) {
    BinaryFormatter formatter = new BinaryFormatter();
    string path = Application.persistentDataPath + "/saveData.dat";
    FileStream stream = new FileStream(path, FileMode.Create);
        
    SaveData data = new SaveData();
    data.playerPosition = playerTransform.position;
        
    formatter.Serialize(stream, data);
    stream.Close();
    }

    public static SaveData LoadGame() {
        string path = Application.persistentDataPath + "/saveData.dat";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
                
            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }


}
