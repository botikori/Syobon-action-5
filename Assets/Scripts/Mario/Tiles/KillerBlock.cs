//using Mario.Characters;
using UnityEngine;

namespace Mario.Tiles
{
    public class KillerBlock : Tile
    {
        private void OnPlayerEnter()
        {
            Debug.Log("player entered");
        }
    }
}
