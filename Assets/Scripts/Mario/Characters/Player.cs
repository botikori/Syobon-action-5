using System.Collections;
using UnityEngine;

namespace Mario.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float jumpHeight = 5f;
        [SerializeField] private float jumpDelay = 0.5f;
        [SerializeField] private AudioClip jumpSound;
        [SerializeField] private LayerMask jumpMask;

        private bool _canJump = true;
        private Rigidbody2D _rigidbody;
        private BoxCollider2D _boxCollider;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _boxCollider = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            Move();
            Jump();
        }
        
        #region Jump
        private void Jump()
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
            {
                if (IsGrounded() && _canJump)
                {
                    _rigidbody.velocity = Vector2.up * jumpHeight;
                    SoundManager.Instance.PlaySound(jumpSound);
                    StartCoroutine(JumpDelay());
                }
            }
        }

        private IEnumerator JumpDelay()
        {
            _canJump = false;
            yield return new WaitForSeconds(jumpDelay);
            _canJump = true;
        }
        
        private bool IsGrounded()
        {
            RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0, Vector2.down, 0.1f, jumpMask);

            return raycastHit.collider != null;
        }
        #endregion

        private void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");

            transform.position += new Vector3(horizontal * moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}