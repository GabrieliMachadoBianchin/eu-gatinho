using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 4f;
    public float runSpeed = 7f;
    public float rotationSpeed = 10f;

    [Header("Jump")]
    public float jumpForce = 7f;

    [Header("References")]
    public Transform cameraTransform;

    private Rigidbody rb;
    private PlayerAnimation playerAnimation;

    private Vector3 movement;

    private bool isGrounded;

    public bool IsGrounded => isGrounded;
    public float SpeedPercent { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<PlayerAnimation>();

        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    private void Update()
    {
        ReadInput();

        HandleJump();

        playerAnimation.UpdateMovement(
            SpeedPercent,
            isGrounded);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void ReadInput()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        movement = (forward * v + right * h).normalized;

        SpeedPercent = movement.magnitude;
    }

    void MovePlayer()
    {
        if (movement.magnitude < 0.1f)
            return;

        float speed = Input.GetKey(KeyCode.LeftShift)
            ? runSpeed
            : walkSpeed;

        Vector3 targetPosition =
            rb.position + movement * speed * Time.fixedDeltaTime;

        rb.MovePosition(targetPosition);

        Quaternion targetRotation =
            Quaternion.LookRotation(movement);

        rb.MoveRotation(
            Quaternion.Slerp(
                rb.rotation,
                targetRotation,
                rotationSpeed * Time.fixedDeltaTime));
    }

    void HandleJump()
    {
        if (!isGrounded)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(
                Vector3.up * jumpForce,
                ForceMode.Impulse);

            isGrounded = false;

            playerAnimation.Jump();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                return;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}