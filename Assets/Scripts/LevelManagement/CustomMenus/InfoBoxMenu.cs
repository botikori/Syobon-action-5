using Mario.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement.CustomMenus
{
    public class InfoBoxMenu : Menu<InfoBoxMenu>
    {
        [Header("Info box properties")]
        [SerializeField] private Text title;
        [SerializeField] private Text mainText;

        public void SetProperties(InfoBox infoBox)
        {
            if (title != null && mainText != null)
            {
                title.text = infoBox.title;
                mainText.text = infoBox.text;
            }
        }
    }
}