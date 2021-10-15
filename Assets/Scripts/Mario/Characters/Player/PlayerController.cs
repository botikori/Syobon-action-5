using System;
using System.Collections;
using Mario.Tiles.StackablePoles;
using UnityEngine;

namespace Mario.Characters.Player
{
    [RequireComponent(typeof(Player))]
    public class PlayerController : CharacterController
    {
        [Header("Jump parameters")] [SerializeField]
        private float jumpVelocity = 15.0f;

        [SerializeField] private float jumpDelay = 0.5f;

        [Header("Movement parameters")] [SerializeField]
        private float moveSpeed = 10.0f;

        [Header("Pipe variables")] [SerializeField]
        private float pipeGoDownSpeed = 1f; 
        
        private bool _canJump = true;
        private bool _isPipeEvent;

        public event Action<Pipe> PipeGoDown; 

        private Player _player;

        private void Start()
        {
            _player = GetComponent<Player>();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (!_isPipeEvent)
            {
                HandleJump();
                HandleMovement();
            }
            
            HandlePipe();
        }

        private void HandleJump()
        {
            if (Input.GetKey(KeyCode.UpArrow) && IsGrounded() && _canJump)
            {
                Rigidbody2D.velocity = Vector2.up * jumpVelocity;

                StartCoroutine(DelayJump());
            }
        }

        private IEnumerator DelayJump()
        {
            _canJump = false;
            yield return new WaitForSeconds(jumpDelay);
            _canJump = true;
        }

        private void HandleMovement()
        {
            float horizontal = Input.GetAxis("Horizontal");
            Rigidbody2D.velocity = new Vector2(horizontal * moveSpeed, Rigidbody2D.velocity.y);
        }

        private void HandlePipe()
        {
            if (Input.GetKey(KeyCode.DownArrow) && _player.StandOnPipe != null)
            {
                _isPipeEvent = true;
                Rigidbody2D.bodyType = RigidbodyType2D.Static;

                if (PipeGoDown != null)
                {
                    PipeGoDown.Invoke(_player.StandOnPipe);
                }
            }

            if (_isPipeEvent)
            {
                transform.position = new Vector3(transform.position.x, 
                    transform.position.y - pipeGoDownSpeed  * Time.deltaTime, transform.position.z);
            }
        }
    }
}