using UnityEngine;

namespace Mario
{
    public class GameMenu : Menu<GameMenu>
    {
        public void OnPausePressed()
        {
            Time.timeScale = 0;

            PauseMenu.Open();
        }
    }   
}
