using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Mario.Tiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FallingBlock : Tile
    {
        public bool IsFalling { get; set; } = false;
        
        public void OnPlayerEnter()
        {
            if (!IsFalling)
            {
                List<FallingBlock> fallingBlocks = FindObjectsOfType<FallingBlock>().ToList();

                foreach (var fallingBlock in fallingBlocks)
                {
                    fallingBlock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    fallingBlock.IsFalling = true;
                }
            }
        }
    }
}
