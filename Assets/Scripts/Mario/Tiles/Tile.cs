using System;
using UnityEngine;

namespace Mario.Tiles
{
    public class Tile : MonoBehaviour
    {
        public virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                gameObject.SendMessage("OnPlayerEnter", other);
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                gameObject.SendMessage("OnPlayerExit", other);
            }
        }
    }
}