using UnityEngine;
using UnityEngine.SceneManagement;
using MenuManagement;

namespace LevelManagement
{
    public static class LevelLoader
    {
        private static int mainMenuBuildIndex = 0;
        
        public static void LoadScene(int sceneIndex)
        {
            if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                if (sceneIndex == mainMenuBuildIndex)
                {
                    MainMenu.Open();
                }
                
                SceneManager.LoadScene(sceneIndex);
            }
            else
            {
                Debug.LogWarning($"Incorrect scene number: {sceneIndex}");
            }
        }

        public static void LoadScene(string sceneName)
        {
            if (Application.CanStreamedLevelBeLoaded(sceneName))
            {
                SceneManager.LoadScene(sceneName);   
            }
            else
            {
                Debug.LogWarning($"Incorrect scene name: {sceneName}");
            }
        }

        public static void LoadNextLevel()
        {
            var currentScene = SceneManager.GetActiveScene();
            int currentSceneBuildIndex = currentScene.buildIndex;

            int nextSceneIndex = currentSceneBuildIndex + 1;
            int totalSceneCount = SceneManager.sceneCountInBuildSettings;
            
            nextSceneIndex = nextSceneIndex % totalSceneCount;
            LoadScene(nextSceneIndex);
        }

        public static void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public static void LoadMainMenu()
        {
            LoadScene(mainMenuBuildIndex);
        }
    }
}