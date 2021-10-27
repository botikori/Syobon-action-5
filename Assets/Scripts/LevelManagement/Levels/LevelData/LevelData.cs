using UnityEngine;

namespace LevelManagement.Levels.LevelData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData")]
    public class LevelData : ScriptableObject
    {
        public LevelName levelName;
        public bool isCheckPoint = true;
    }
}