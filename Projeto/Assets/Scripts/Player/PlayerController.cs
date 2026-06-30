using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 4f;
    public float runSpeed = 7f;
    public float rotationSpeed = 10f;

    [Header("Jump")]
    public float jumpHeight = 1.5f;
    public float gravity = -20f;

    [Header("References")]
    public Transform cameraTransform;

    private CharacterController controller;
    private PlayerAnimation playerAnimation;

    private Vector3 velocity;
    private bool isGrounded;

    public bool IsGrounded => isGrounded;
    public float SpeedPercent { get; private set; }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        GroundCheck();

        Move();

        ApplyGravity();

        Jump();

        playerAnimation.UpdateAnimation(SpeedPercent, isGrounded);
    }

    private void GroundCheck()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(horizontal, 0, vertical);

        SpeedPercent = Mathf.Clamp01(input.magnitude);

        if (input.magnitude < 0.1f)
            return;

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * vertical + right * horizontal;

        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        controller.Move(moveDirection.normalized * speed * Time.deltaTime);

        Quaternion targetRotation =
            Quaternion.LookRotation(moveDirection);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            playerAnimation.Jump();
        }
    }

    private void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}