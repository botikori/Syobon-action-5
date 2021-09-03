using UnityEngine;
using LevelManagement;
using LevelManagement.Utilities;

namespace MenuManagement
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