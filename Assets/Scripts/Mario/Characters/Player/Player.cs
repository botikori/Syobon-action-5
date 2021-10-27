using Mario.Tiles.StackablePoles;
using UnityEngine;

namespace Mario.Characters.Player
{
    public class Player : MonoBehaviour
    {
        private Pipe _pipe;
        public Pipe StandOnPipe { get; set; } = null;
        
        private void Start()
        {
            _pipe = FindObjectOfType<Pipe>();

            if (_pipe != null)
            {
                _pipe.PipeEntered += OnPipeEntered;
                _pipe.PipeExited += OnPipeExited;
            }
            
        }

        private void OnDestroy()
        {
            if (_pipe != null)
            {
                _pipe.PipeEntered -= OnPipeEntered;
                _pipe.PipeExited -= OnPipeExited;
            }
        }

        private void OnPipeEntered(Pipe pipe)
        {
            StandOnPipe = pipe;
        }

        private void OnPipeExited()
        {
            StandOnPipe = null;
        }
    }
}