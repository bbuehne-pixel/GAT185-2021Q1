using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [Range(0, 20)] public float speed = 1;
    [Range(0, 20)] public float jump = 1;
    [Range(-20, 20)] public float gravity = -9.8f;

    CharacterController characterController;
    Vector3 inputDirection; // field
    Vector3 velocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        bool onGround = characterController.isGrounded;
        if(onGround && velocity.y < 0)
        {
            velocity.y = 0;
        }

        inputDirection = Vector3.zero;
        inputDirection.x = Input.GetAxis("Horizontal");
        inputDirection.z = Input.GetAxis("Vertical");

        if(inputDirection.magnitude > 0.1f)
        {
            transform.forward = inputDirection.normalized;
        }

        characterController.Move(inputDirection * speed * Time.deltaTime);

        // jump
        if(Input.GetButtonDown("Jump") && onGround)
        {
            velocity.y += jump;
        }

        // gravity movement
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
