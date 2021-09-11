using UnityEngine;

namespace Mario.Tiles.HitBlocks
{
    public class LuckyBlock : MonoBehaviour, IBlockHit
    {
        [SerializeField] private Sprite openedTile;
        [SerializeField] private AudioClip hitSound;

        [SerializeField] private GameObject gameObjectToSpawn;
        [SerializeField] private float spawnedObjectOffsetY;

        private bool _isOpened = false;

        public void BlockHit()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            if (spriteRenderer != null && !_isOpened)
            {
                spriteRenderer.sprite = openedTile;
                SoundManager.Instance.PlaySound(hitSound);
                _isOpened = true;
                
                if (gameObjectToSpawn != null)
                {
                    Vector3 spawnPosition = new Vector3(transform.position.x,
                        transform.position.y + spawnedObjectOffsetY,
                        transform.position.z);
                    Instantiate(gameObjectToSpawn, spawnPosition, Quaternion.identity, transform);
                }
            }
        }
    }
}