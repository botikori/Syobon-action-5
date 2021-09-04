using LevelManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mario
{
    public class PauseMenu : Menu<PauseMenu>
    {
        [SerializeField] private int mainMenuBuildIndex = 0;
        
        public void OnResumePressed()
        {
            Time.timeScale = 1;
            base.OnBackPressed();
        }

        public void OnRestartPressed()
        {
            Time.timeScale = 1;
            LevelLoader.ReloadLevel();
            base.OnBackPressed();
        }

        public void OnMainMenuPressed()
        {
            Time.timeScale = 1;
            LevelLoader.LoadMainMenu();
            MainMenu.Open();
        }

        public override void OnBackPressed()
        {
            Application.Quit();
        }
    }   
}
