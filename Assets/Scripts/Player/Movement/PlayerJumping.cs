using System.Collections.Generic;
using UnityEngine;

namespace Player.Movement
{
    public class PlayerJumping : MonoBehaviour
    {
        [Header("Input")] 
        [SerializeField] private KeyCode jumpKey = KeyCode.Space;
        
        [Header("Jump")]
        [SerializeField] private float gravityScale = 9f;
        [SerializeField] private float jumpForce = 35f;
        
        [Header("Ground check")] 
        [SerializeField] private Collider2D selfCollider;
        [SerializeField] private List<Transform> onGroundCheckers;
        [SerializeField] private float checkRayLength = 0.01f;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.gravityScale = gravityScale;
        }

        private void Update()
        {
            if (!Input.GetKeyDown(jumpKey)) return;
            if (!OnGround()) return;
            Jump();
        }

        /// <summary>
        /// On ground check. Checkers must be under the player collider, otherwise rays always would detect collision 
        /// </summary>
        private bool OnGround()
        {
            foreach (var checker in onGroundCheckers)
            {
                var hits = Physics2D.RaycastAll(checker.position, Vector2.down, checkRayLength);
                //if (hits.Length == 0) continue;
                foreach (var hit in hits)
                {
                    if (hit.collider != selfCollider) return true;
                }
            }
            return false;
        }

        private void Jump() => _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}