using System;
using UnityEngine;

namespace Mario.Characters.Player
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(Player))]
    public class PlayerAnimator : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        private PlayerController _playerController;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            _playerController = GetComponent<PlayerController>();
        }

        private void Update()
        {
            HandleAnimations();
        }

        private void HandleAnimations()
        {
            if (_playerController.Rigidbody2D.velocity.x > 0.1)
            {
                _animator.SetBool("IsMoving", true);
                _spriteRenderer.flipX = false;
            }
            else if (_playerController.Rigidbody2D.velocity.x < -0.1)
            {
                _animator.SetBool("IsMoving", true);
                _spriteRenderer.flipX = true;
            }
            else
            {
                _animator.SetBool("IsMoving", false);
            }

            _animator.SetBool("IsGrounded", _playerController.IsGrounded());
        }
    }
}