using System.Collections;
using UnityEngine;
using Scripts.Utils;
using Assets.Scripts.SceneManager;
using Assets.Scripts.Core.Manager;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float FowardMoveSpeed = 3f;
        private float _originalFowardSpeed;

        [SerializeField] private float moveSpeed;
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private float jumpHeight;

        private float _gravityValue = -9.8f;
        private bool _isGrounded;
        private float _velocity;
        private bool _canMove;

        private AnimationManager _animator;

        private void Start()
        {
            _canMove = false;
            _animator = GetComponent<AnimationManager>();
            _animator.TriggerAnimation("Idle");
            StartCoroutine(CountToMove());
        }
        private IEnumerator CountToMove()
        {
            yield return new WaitForSeconds(1.5f);
            _canMove = true;
            _originalFowardSpeed = FowardMoveSpeed;
            _animator.TriggerAnimation("Run");

        }

        void Update()
        {
            _isGrounded = JumpRaycaster.CheckIfIsGrounded(gameObject.GetComponent<Collider>(), 0.2f);
            _velocity += _gravityValue * Time.deltaTime;
            Move(Player.isAlive);
        }
        public void Move(bool isAlive)
        {
            if (isAlive && !GameManager.IsPlayerReachedFinishlLine && _canMove)
            {
                transform.Translate(Vector3.forward * FowardMoveSpeed * Time.deltaTime);
                TouchSimulator.MoveInAbscissaByTouchSimulation(transform, horizontalSpeed);
                SetPlayerVerticalVelocityToZero();
                CheckJump();
            }
        }
        private void SetPlayerVerticalVelocityToZero()
        {
            if (_isGrounded && _velocity < 0)
            {
                _velocity = 0;
            }
        }
        private void CheckJump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                _velocity = Mathf.Sqrt(jumpHeight * -3f * _gravityValue);
            }
            transform.Translate(Vector3.up * _velocity * Time.deltaTime);
        }

        public void SetOriginalFowardSpeed()
        {
            FowardMoveSpeed = _originalFowardSpeed;
        }

    }
}