using LevelManagement.CustomMenus;
using Mario.ScriptableObjects;
using UnityEngine;

namespace Mario.Tiles.HitBlocks
{
    public class InfoboxHit : MonoBehaviour, IBlockHit
    {
        [SerializeField] private InfoBox infoBox;
        
        public void BlockHit()
        {
            InfoBoxMenu.Instance.SetProperties(infoBox);
            InfoBoxMenu.Open();
            Time.timeScale = 0;
        }
    }
}