using UnityEngine;

namespace Mario.Tiles.HitBlocks
{
    public class Block : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var hit = GetComponent<IBlockHit>();
            
            hit.BlockHit();
        }
    }
}