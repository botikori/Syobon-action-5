using System;
using System.Collections;
using UnityEngine;

namespace Mario.Characters
{
    public class PlayerController : CharacterController
    {
        [Header("Jump parameters")]
        [SerializeField] private float jumpVelocity = 15.0f;
        [SerializeField] private float jumpDelay = 0.5f;
        
        [Header("Movement parameters")]
        [SerializeField] private float moveSpeed = 10.0f;

        private bool _canJump = true;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        public override void Awake()
        {
            base.Awake();
            
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public override void Update()
        {
            base.Update();
            
            HandleJump();
            HandleMovement();
            _animator.SetBool("IsGrounded", IsGrounded());
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
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Rigidbody2D.velocity = new Vector2(-moveSpeed, Rigidbody2D.velocity.y);
                _animator.SetBool("IsMoving", true);
                _spriteRenderer.flipX = true;
            }
            else
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    Rigidbody2D.velocity = new Vector2(moveSpeed, Rigidbody2D.velocity.y);
                    _animator.SetBool("IsMoving", true);
                    _spriteRenderer.flipX = false;
                }
                else
                {
                    Rigidbody2D.velocity = new Vector2(0, Rigidbody2D.velocity.y);
                    _animator.SetBool("IsMoving", false);
                }
            }
        }
    }
}