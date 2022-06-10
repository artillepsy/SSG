using UnityEngine;

namespace Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float force = 120f;
        [SerializeField] private float maxSpeed = 12f;
        private Rigidbody2D _rb;

        private void Awake() => _rb = GetComponent<Rigidbody2D>();

        private void FixedUpdate()
        {
            var inputValue = Input.GetAxisRaw("Horizontal");
            var velocity = Vector2.right * (inputValue * force);
            
            _rb.AddForce(velocity, ForceMode2D.Force);

            var velocityX = Mathf.Clamp(_rb.velocity.x, -maxSpeed, maxSpeed);
            
            _rb.velocity = new Vector2(velocityX, _rb.velocity.y);
        }
    }
}
