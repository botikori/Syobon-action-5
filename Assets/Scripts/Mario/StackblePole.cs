using System;
using UnityEngine;

namespace Mario
{
    [ExecuteInEditMode]
    public class StackblePole : MonoBehaviour
    {
        [SerializeField] private Sprite poleBottom;
        [SerializeField] private Sprite poleMiddle;
        [SerializeField] private Sprite poleTop;

        [SerializeField] private int poleHeight;

        [SerializeField] private bool isDrawn = false;

        private void DrawPole()
        {
            if (!isDrawn)
            {
                for (int i = 0; i < poleHeight; i++)
                {
                    Debug.Log("here");
                    var polePart = Instantiate(new GameObject(),
                        new Vector3(transform.position.x, transform.position.y + i, transform.position.z),
                        Quaternion.identity, transform);

                    var poleSprite = polePart.AddComponent<SpriteRenderer>() as SpriteRenderer;
                    
                    if (i == 0)
                    {
                        poleSprite.sprite = poleBottom;
                    }
                    else if (i == poleHeight - 1)
                    {
                        poleSprite.sprite = poleTop;
                    }
                    else
                    {
                        poleSprite.sprite = poleMiddle;
                    }
                }
                isDrawn = true;
            }
        }

        private void Update()
        {
            DrawPole();
        }
    }
}