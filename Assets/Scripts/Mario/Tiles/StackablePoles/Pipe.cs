using System;
using UnityEngine;

namespace Mario.Tiles.StackablePoles
{
    public class Pipe : MonoBehaviour
    {
        [SerializeField] private bool canGoDown;
        [SerializeField] private string sceneToLoad;

        public event Action<Pipe> PipeEntered;
        public event Action PipeExited;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && PipeEntered != null)
            {
                PipeEntered.Invoke(this);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player") && PipeExited != null)
            {
                PipeExited.Invoke();
            }
        }
    }
}