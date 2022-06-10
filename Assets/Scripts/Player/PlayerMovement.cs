using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
       

        private Rigidbody2D _rb;
        private float _currentSpeed = 0f;
        


        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }


        private void Update()
        {
        
        }

       
    }
}
