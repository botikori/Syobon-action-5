using UnityEngine;

namespace Mario.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10f;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            
            Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.velocity = Vector3.right * horizontal * moveSpeed;
        }
    }
}