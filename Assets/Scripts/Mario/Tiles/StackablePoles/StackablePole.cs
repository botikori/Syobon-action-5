using UnityEngine;

namespace Mario.Tiles
{
    public class StackablePole : MonoBehaviour
    {
        [Header("Pole sprites")]
        [SerializeField] private Sprite poleBottom;
        [SerializeField] private Sprite poleMiddle;
        [SerializeField] private Sprite poleTop;
        
        [Header("Pole game objects")]
        [SerializeField] private GameObject topGameObject;
        [SerializeField] private GameObject poleGameObject;
        
        [Header("Pole height")]
        [SerializeField] private int poleHeight;

        private void Awake()
        {
            DrawPole(poleHeight);

            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            
            if (spriteRenderer != null)
            {
                Destroy(spriteRenderer);
            }
        }

        private void DrawPole(int height)
        {
            for (int i = 0; i < height; i++)
            {
                if (i == 0)
                {
                    InstantiatePole(poleGameObject, i, poleBottom);
                }
                else if (i == height - 1)
                {
                    InstantiatePole(topGameObject, i, poleTop);
                }
                else
                {
                    InstantiatePole(poleGameObject, i, poleMiddle);
                }
            }
        }

        private void InstantiatePole(GameObject instantiateGameObject, int height, Sprite sprite)
        {
            GameObject polePart = Instantiate(instantiateGameObject,
                new Vector3(transform.position.x, transform.position.y + height, transform.position.z),
                Quaternion.identity, transform);

            SpriteRenderer spriteRenderer = polePart.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = sprite;
            }
        }
    }
}