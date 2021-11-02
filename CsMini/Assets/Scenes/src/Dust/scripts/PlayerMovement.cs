using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 4f;
    public float slowSpeed = 2f;
    public float gravity = -12f;
    public float jumpHeight = 1.8f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    protected Joystick joystick;
    protected JoyButton joyButton;

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joyButton = FindObjectOfType<JoyButton>();
    }

    // Update is called once per frame
    void Update()
    {

        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal") + joystick.Horizontal;
        float z = Input.GetAxis("Vertical") + joystick.Vertical;


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * getSpeed(isGrounded) * Time.deltaTime);


        if ((joyButton.pressed || Input.GetButtonDown("Jump")) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    float getSpeed(bool isGrounded)
    {
        return Input.GetKey(KeyCode.LeftShift) && isGrounded ? slowSpeed : speed;
    }
}
