using System;
using UnityEngine;

namespace Mario.Tiles.StackablePoles
{
    public class Pipe : Tile
    {
        [SerializeField] private bool canGoDown;
        [SerializeField] private string sceneToLoad;

        public event Action<Pipe> PipeEntered;
        public event Action PipeExited;

        private void OnPlayerEnter()
        {
            if (PipeEntered == null)
            {
                return;
            }

            PipeEntered.Invoke(this);
        }

        private void OnPlayerExit()
        {
            if (PipeExited == null)
            {
                return;
            }

            PipeExited.Invoke();
        }
    }
}