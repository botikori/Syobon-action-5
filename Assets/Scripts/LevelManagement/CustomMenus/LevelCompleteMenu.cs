using LevelManagement.Levels;

namespace LevelManagement.CustomMenus
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