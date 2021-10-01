using System;
using UnityEngine;

namespace Mario.Characters
{
    public class CharacterController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private BoxCollider2D _boxCollider;

        public Rigidbody2D Rigidbody2D
        {
            get => _rigidbody2D;
            set => _rigidbody2D = value;
        }

        public BoxCollider2D BoxCollider
        {
            get => _boxCollider;
            set => _boxCollider = value;
        }

        [Header("Gravity modifier")] [SerializeField]
        private float fallMultiplier = 2.5f;

        [SerializeField] private float lowJumpMultiplier = 2f;

        [Header("Grounded mask")] [SerializeField]
        private LayerMask jumpLayer;

        public virtual void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _boxCollider = GetComponent<BoxCollider2D>();
        }

        public virtual void FixedUpdate()
        {
            ModifyGravity();
        }

        private void ModifyGravity()
        {
            if (_rigidbody2D.velocity.y < 0)
            {
                _rigidbody2D.gravityScale = fallMultiplier;
            }
            else if (_rigidbody2D.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow) && !IsGrounded())
            {
                _rigidbody2D.gravityScale = lowJumpMultiplier;
            }
            else
            {
                _rigidbody2D.gravityScale = 1.0f;
            }
        }

        public bool IsGrounded()
        {
            RaycastHit2D raycastHit2D = Physics2D.BoxCast(_boxCollider.bounds.center,
                _boxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpLayer);
            return raycastHit2D.collider != null;
        }
    }
}