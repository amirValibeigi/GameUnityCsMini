using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region
    public static GameObject instance;

    private void Awake()
    {
        instance = this.gameObject;
    }
    #endregion

    public CharacterController controller;

    [Header("Move Variables")]
    public float speed = 4f;
    public float slowSpeed = 2f;
    public float gravity = -12f;
    public float jumpHeight = 0.8f;


    [Header("Gravity")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    [Header("Buttons")]
    protected Joystick joystick;
    protected JumpButton jumpButton;


    [Header("Animations")]
    private Animator animator;



    [Header("Audio")]
    [SerializeField] private AudioClip audioClipFootSteps;
    private Vector3 velocity;
    private Vector3 move;
    private AudioSource audioFootSteps;



    // Start is called before the first frame update
    void Start()
    {
        getReferences();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        handleAnimations();
    }

    private void getReferences()
    {
        joystick = FindObjectOfType<Joystick>();
        jumpButton = FindObjectOfType<JumpButton>();
        animator = GetComponentInChildren<Animator>();
        audioFootSteps = GetComponent<AudioSource>();
    }


    private void handleAnimations()
    {
        if (move == Vector3.zero)
        {
            animator.SetFloat("speed", 0f);
        }
        else
        {
            animator.SetFloat("speed", 1f);
        }
    }


    private void movement()
    {

        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal") + joystick.Horizontal;
        float z = Input.GetAxis("Vertical") + joystick.Vertical;


        move = transform.right * x + transform.forward * z;

        controller.Move(move * getSpeed(isGrounded) * Time.deltaTime);


        if ((jumpButton.pressed || Input.GetButtonDown("Jump")) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (isGrounded && (x + z) != 0f && !audioFootSteps.isPlaying)
        {
            audioFootSteps.PlayOneShot(audioClipFootSteps, 0.4f);
        }
    }


    float getSpeed(bool isGrounded)
    {
        return Input.GetKey(KeyCode.LeftShift) && isGrounded ? slowSpeed : speed;
    }
}
