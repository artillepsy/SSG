using UnityEngine;

namespace Player.Movement
{
    /// <summary>
    /// Unused already
    /// </summary>
    public class PlayerMovementAcceleration : MonoBehaviour
    {
        [SerializeField] private AnimationCurve accelerationCurve;
        [SerializeField] private float accelerationTime = 0.3f;

        private float _speedCoefficient = 0f;
        private float _inputTime = 0f;

        public float SpeedCoefficient => _speedCoefficient;

        private void Update()
        {
            var inputValue = Input.GetAxisRaw("Horizontal");

            _inputTime += inputValue == 0 ? -Time.deltaTime : Time.deltaTime;
            _inputTime = Mathf.Clamp(_inputTime, 0, accelerationTime);

            _speedCoefficient = accelerationCurve.Evaluate(_inputTime / accelerationTime);
        }
    }
}