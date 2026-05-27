using UnityEngine;
using System.IO;
using Solution;
using System.Data.Common;
using Newtonsoft.Json.Serialization;
namespace Solution
{
    public class JsonSafeModeSystem
    {
        private static string saveFilePath = Application.persistentDataPath + "/savefile.json";
        public static void SaveGame(PlayerScore data)
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(saveFilePath, json);
            Debug.Log("Game save to " + saveFilePath);
        }
        public static PlayerScore LoadGame()
        {
            if (File.Exists(saveFilePath))
            {
                string json = File.ReadAllText(saveFilePath);
                PlayerScore data = JsonUtility.FromJson<PlayerScore>(json);
                Debug.Log("Game Loaded");
                return data;
            }
            else
            {
                return null;
            }

            
        }
    }

}
