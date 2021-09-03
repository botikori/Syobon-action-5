using LevelManagement;
using UnityEngine;

namespace MenuManagement
{
    public class GameOverMenu : Menu<GameOverMenu>
    {
        public void OnRestartPressed()
        {
            Time.timeScale = 1;
            LevelLoader.ReloadLevel();
            GameMenu.Open();
        }

        public void OnMainMenuPressed()
        {
            Time.timeScale = 1;
            LevelLoader.LoadMainMenu();
            MainMenu.Open();
        }
    }
}