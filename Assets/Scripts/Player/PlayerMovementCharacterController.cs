using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scripts.Core.Interfaces;
using Scripts.Utils;

public class PlayerMovementCharacterController : MonoBehaviour, IMovable
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float jumpHeight;

    private CharacterController _controller;
    private Vector3 playerVelocity;
    private float gravityValue = -9.8f;
    private float fowardMoveSpeed = 3f;
    private bool isGrounded;
    private Vector3 playerMove;

    void Start()
    {
        InitComponents();
    }
    private void InitComponents()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move(true);
    }
    public void Move(bool isAlive)
    {
        if (isAlive)
        {
            isGrounded = JumpRaycaster.CheckIfIsGrounded(gameObject.GetComponent<Collider>(), 0.2f);
            
            SetPlayerVerticalVelocityToZero();

            playerMove = new Vector3(0, 0, fowardMoveSpeed);
            _controller.Move(playerMove * Time.deltaTime);

            CheckJump();
        }

    }
    private void SetPlayerVerticalVelocityToZero()
    {
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }
    }
    private void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        _controller.Move(playerVelocity * Time.deltaTime);
    }

   
}
