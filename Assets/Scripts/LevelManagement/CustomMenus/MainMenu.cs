using UnityEngine;

namespace LevelManagement.CustomMenus
{
    public class MainMenu : Menu<MainMenu>
    {
        public void OnLevelSelectorPressed()
        {
            Debug.Log("Level selector");
        }

        public void OnSettingsPressed()
        {
            Debug.Log("Settings");
            SettingsMenu.Open();
        }
        
        public void OnQuitPressed()
        {
            Application.Quit();
        }
        
    }
}