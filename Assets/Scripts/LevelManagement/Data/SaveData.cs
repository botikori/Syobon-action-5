using System;
using UnityEngine.Serialization;

namespace MenuManagement.Data
{
    [Serializable]
    public class SaveData
    {
        public float musicVolume;
        public float soundEffectsVolume;

        public string hashValue;

        public SaveData()
        {
            musicVolume = 1;
            soundEffectsVolume = 1;
            hashValue = "";
        }
    }
}
