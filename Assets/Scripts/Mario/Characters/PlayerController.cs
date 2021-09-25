using System;
using System.Collections;
using UnityEngine;

namespace Mario.Characters
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Jump parameters")]
        [SerializeField] private float jumpVelocity = 15.0f;
        [SerializeField] private float fallMultiplier = 2.5f;
        [SerializeField] private float lowJumpMultiplier = 2f;
        [SerializeField] private float jumpDelay = 0.5f;
        [SerializeField] private LayerMask jumpLayer;
        
        [Header("Movement parameters")]
        [SerializeField] private float moveSpeed = 10.0f;

        private bool _canJump = true;
        
        private Rigidbody2D _rigidbody2D;
        private BoxCollider2D _boxCollider;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _boxCollider = GetComponent<BoxCollider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            HandleJump();
            HandleMovement();
            _animator.SetBool("IsGrounded", IsGrounded());
        }

        private void HandleJump()
        {
            if (Input.GetKey(KeyCode.UpArrow) && IsGrounded() && _canJump)
            {
                _rigidbody2D.velocity = Vector2.up * jumpVelocity;

                StartCoroutine(DelayJump());
            }
            
            if (_rigidbody2D.velocity.y < 0)
            {
                _rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (_rigidbody2D.velocity.y >= 0 && !Input.GetKey(KeyCode.UpArrow) && !IsGrounded())
            {
                _rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
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
                _rigidbody2D.velocity = new Vector2(-moveSpeed, _rigidbody2D.velocity.y);
                _animator.SetBool("IsMoving", true);
                _spriteRenderer.flipX = true;
            }
            else
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    _rigidbody2D.velocity = new Vector2(moveSpeed, _rigidbody2D.velocity.y);
                    _animator.SetBool("IsMoving", true);
                    _spriteRenderer.flipX = false;
                }
                else
                {
                    _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
                    _animator.SetBool("IsMoving", false);
                }
            }
        }

        private bool IsGrounded()
        {
            RaycastHit2D raycastHit2D = Physics2D.BoxCast(_boxCollider.bounds.center,
                _boxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpLayer);
            return raycastHit2D.collider != null;
        }
    }
}