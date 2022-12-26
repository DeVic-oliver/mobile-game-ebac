using System.Collections;
using UnityEngine;
using Scripts.Utils;
using Assets.Scripts.SceneManager;
using Assets.Scripts.Items.Powerups;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {

        [SerializeField] private float moveSpeed;
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private float jumpHeight;

        private float gravityValue = -9.8f;
        private float _fowardMoveSpeed = 3f;
        private float _originalFowardSpeed;
        private bool isGrounded;
        private float velocity;


        private void Start()
        {
            _originalFowardSpeed = _fowardMoveSpeed;
        }

        void Update()
        {
            isGrounded = JumpRaycaster.CheckIfIsGrounded(gameObject.GetComponent<Collider>(), 0.2f);
            velocity += gravityValue * Time.deltaTime;
            Move(Player.isAlive);
        }
        public void Move(bool isAlive)
        {
            if (isAlive && !GameManager.IsPlayerReachedFinishlLine)
            {
                transform.Translate(Vector3.forward * _fowardMoveSpeed * Time.deltaTime);
                TouchSimulator.MoveInAbscissaByTouchSimulation(transform, horizontalSpeed);
                SetPlayerVerticalVelocityToZero();
                CheckJump();
            }
        }
        private void SetPlayerVerticalVelocityToZero()
        {
            if (isGrounded && velocity < 0)
            {
                velocity = 0;
            }
        }
        private void CheckJump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                velocity = Mathf.Sqrt(jumpHeight * -3f * gravityValue);
            }
            transform.Translate(Vector3.up * velocity * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            CheckIfGetSpeedPowerUp(collision);
        }
        private void CheckIfGetSpeedPowerUp(Collision powerUpCollider)
        {
            PowerupSpeed speedPowerUp = powerUpCollider.gameObject.GetComponent<PowerupSpeed>();
            
            if(speedPowerUp != null)
            {
                _fowardMoveSpeed = speedPowerUp.GetBuffedValue(_fowardMoveSpeed);
                StartCoroutine(DeactiveBuff(speedPowerUp.GetBuffTimer()));
            }
        }
        private IEnumerator DeactiveBuff(float timer)
        {
            yield return new WaitForSeconds(timer);
            _fowardMoveSpeed = _originalFowardSpeed;
        }
    }
}