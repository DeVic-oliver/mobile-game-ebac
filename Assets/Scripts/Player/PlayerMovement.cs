﻿using System.Collections;
using UnityEngine;
using Scripts.Utils;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {

        public bool isAlive { get; set; }

        [SerializeField] private float moveSpeed;
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private float jumpHeight;

        private float gravityValue = -9.8f;
        private float fowardMoveSpeed = 3f;
        private bool isGrounded;
        private float velocity;

        void Update()
        {
            isGrounded = JumpRaycaster.CheckIfIsGrounded(gameObject.GetComponent<Collider>(), 0.2f);
            velocity += gravityValue * Time.deltaTime;
            Move(isAlive);
        }
        public void Move(bool isAlive)
        {
            if (isAlive)
            {
                transform.Translate(Vector3.forward * fowardMoveSpeed * Time.deltaTime);
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
    }
}