using Mario.ScriptableObjects;
using UnityEngine;

namespace Mario.Tiles.StackablePoles
{
    public class StackablePole : MonoBehaviour
    {
        [Header("Height settings")]
        [SerializeField] private int poleHeight = 5;
        [SerializeField] private float poleOffset = 0.0f;

        [Header("Direction")]
        [SerializeField] private float rotation = 0.0f;
        
        [Header("Pole object")]
        [SerializeField] private PoleProperties poleProperties;
        
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
                if (i == height - 1)
                {
                    InstantiatePole(poleProperties.poleTop, i);
                }
                else
                {
                    InstantiatePole(poleProperties.poleBottom, i);
                }
            }

            transform.rotation = Quaternion.Euler(0,0,rotation);
        }

        private void InstantiatePole(GameObject instantiateGameObject, int height)
        {
            GameObject polePart = Instantiate(instantiateGameObject,
                new Vector3(transform.position.x , transform.position.y + (height + poleOffset), transform.position.z),
                Quaternion.identity, transform);
        }
    }
}