using System.Collections;
using UnityEngine;

namespace Mario.Characters.Player
{
    public class PlayerController : CharacterController
    {
        [Header("Jump parameters")]
        [SerializeField] private float jumpVelocity = 15.0f;
        [SerializeField] private float jumpDelay = 0.5f;
        
        [Header("Movement parameters")]
        [SerializeField] private float moveSpeed = 10.0f;

        private bool _canJump = true;
        
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            
            HandleJump();
            HandleMovement();
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
    }
}