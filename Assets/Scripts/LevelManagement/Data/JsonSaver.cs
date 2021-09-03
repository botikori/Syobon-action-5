using UnityEngine;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MenuManagement.Data
{
    public class JsonSaver
    {
        private static readonly string _fileName = "save.json";

        public static string GetSavePath()
        {
            return Application.persistentDataPath + "/" + _fileName;
        }

        public void Save(SaveData saveData)
        {
            string json = JsonUtility.ToJson(saveData);

            FileStream fileStream = new FileStream(GetSavePath(), FileMode.Create);

            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(json);
            }
        }

        public bool Load(SaveData saveData)
        {

            if (File.Exists(GetSavePath()))
            {
                using (StreamReader reader = new  StreamReader(GetSavePath()))
                {
                    string json = reader.ReadToEnd();
                    JsonUtility.FromJsonOverwrite(json, saveData);
                }
                return true;
            }
            return false;
        }

        public void Delete()
        {
            File.Delete(GetSavePath());
        }
    }
}