using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;

    public float speed = 10f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groudMask;


    bool isGrounded;

    Vector3 velocity;

    public float jumpHeight = 3f;


    public bool isSPrinting;

    public float sprintingSpeedMultiplier = 3f;

    private float sprintSpeed = 1;

    public float staminaUseAmount = 2;

    private StaminaBar staminaSlider;

    void Start()
    {
        staminaSlider = FindObjectOfType<StaminaBar>();
    }

    
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius,groudMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        JumpCheck();

        RunCheck();

        characterController.Move(move * speed * Time.deltaTime * sprintSpeed);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }


    public void JumpCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }


    public void RunCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSPrinting = !isSPrinting;

            if (isSPrinting == true)
            {
                staminaSlider.UseStamina(staminaUseAmount);
            }
            else
            {
                staminaSlider.UseStamina(0);
            }
        }

        if (isSPrinting == true)
        {
            sprintSpeed = sprintingSpeedMultiplier;            
        }
        else
        {
            sprintSpeed = 1;
            
        }
    }
}
