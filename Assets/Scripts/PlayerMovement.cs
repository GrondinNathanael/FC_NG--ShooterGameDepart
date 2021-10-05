using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    [SerializeField] private Transform viewingCamera;
    [SerializeField] private float playerSpeed = 20f;

    [SerializeField] private float gravity = 20f;
    [SerializeField] private float jumpSpeed = 20f;
    private float vecticalMovement = 0f;

    private Vector3 direction;
    private float rotationTime = 0.1f;
    private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageSurfaceMovement();
        ManageVerticalMovement();

        characterController.Move(direction);
    }

    private void ManageSurfaceMovement()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + viewingCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, rotationTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            float tempSpeed = playerSpeed;
            if (!characterController.isGrounded) tempSpeed /= 2;

            Vector3 moveDirection = (Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward);

            direction.x = moveDirection.x * tempSpeed * Time.deltaTime;
            direction.z = moveDirection.z * tempSpeed * Time.deltaTime;
        }
        else
        {
            direction = Vector3.zero;
        }
    }

    private void ManageVerticalMovement()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if (characterController.isGrounded)
            {
                vecticalMovement = jumpSpeed;
            }
        }

        vecticalMovement -= gravity * Time.deltaTime;
        direction.y = vecticalMovement * Time.deltaTime;
    }
}
