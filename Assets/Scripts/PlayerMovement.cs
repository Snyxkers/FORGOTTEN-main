using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;

    private Animator animator;

    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float sprintSpeed = 15f;

    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    private Vector3 velocity;

    private float originalHeight;
    private Vector3 originalCenter;

    public float crouchHeight = 1f;

    void Start()
    {
        animator = GetComponent<Animator>();

        originalHeight = controller.height;
        originalCenter = controller.center;
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        bool grounded = controller.isGrounded;

        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
            animator.SetBool("isJumping", false);
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 move = forward * vertical + right * horizontal;

        bool isMoving = move.magnitude > 0.1f;

        // CROUCH
        bool isCrouching = Input.GetKey(KeyCode.LeftControl);

        animator.SetBool("isCrouching", isCrouching);

        if (isCrouching)
        {
            controller.height = crouchHeight;

            controller.center = new Vector3(
                originalCenter.x,
                crouchHeight / 2f,
                originalCenter.z
            );
        }
        else
        {
            controller.height = originalHeight;
            controller.center = originalCenter;
        }

        // SPRINT
        bool isSprinting =
            isMoving &&
            Input.GetKey(KeyCode.LeftShift) &&
            !isCrouching;

        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isSprinting", isSprinting);

        // PLAYER ROTATION
        if (isMoving)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        // PLAYER MOVEMENT
        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;

        controller.Move(
            move.normalized * currentSpeed * Time.deltaTime
        );

        // JUMP
        if (Input.GetButtonDown("Jump") && grounded && !isCrouching)
        {
            velocity.y = Mathf.Sqrt(
                jumpHeight * -2f * gravity
            );

            animator.SetBool("isJumping", true);
        }

        // GRAVITY
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}