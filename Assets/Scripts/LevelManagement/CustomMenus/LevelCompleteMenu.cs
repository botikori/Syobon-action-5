using UnityEngine;
using LevelManagement;
using LevelManagement.Utilities;

namespace Mario
{
    public class LevelCompleteMenu : GameOverMenu
    {
        public void OnNextLevelPressed()
        {
            base.OnBackPressed();
            LevelLoader.LoadNextLevel();
        }
    }
}