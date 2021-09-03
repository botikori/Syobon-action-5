using System.Collections;
using LevelManagement;
using LevelManagement.Utilities;
using MenuManagement.Data;
using UnityEngine;
using UnityEngine.UI;

namespace MenuManagement
{
    public class MainMenu : Menu<MainMenu>
    {
        public void OnLevelSelectorPressed()
        {
            Debug.Log("Level selector");
        }
    }
}