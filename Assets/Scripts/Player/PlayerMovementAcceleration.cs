using UnityEngine;

namespace Player
{
    public class PlayerMovementAcceleration : MonoBehaviour
    {
        [SerializeField] private Animation accelerationCurve;
        [SerializeField] private float accelerationTime = 0.3f;
        private float _inputTime = 0f;
        
        private void IncrementInputTime()
        {
            if (_inputTime > accelerationTime)
            {
                _inputTime = accelerationTime;
                return;
            }

            _inputTime += Time.deltaTime;
        }

        private void DecrementInputTime()
        {
            if (_inputTime < 0f)
            {
                _inputTime = 0f;
                return;
            }

            _inputTime -= Time.deltaTime;
        }
    }
}