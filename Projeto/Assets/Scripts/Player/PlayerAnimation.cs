using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private readonly int SpeedHash = Animator.StringToHash("Speed");
    private readonly int GroundedHash = Animator.StringToHash("Grounded");
    private readonly int JumpHash = Animator.StringToHash("Jump");
    private readonly int HitHash = Animator.StringToHash("Hit");
    private readonly int DeadHash = Animator.StringToHash("Dead");
    private readonly int WinHash = Animator.StringToHash("Win");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void UpdateAnimation(float speed, bool grounded)
    {
        animator.SetFloat(SpeedHash, speed, 0.1f, Time.deltaTime);
        animator.SetBool(GroundedHash, grounded);
    }

    public void Jump()
    {
        animator.SetTrigger(JumpHash);
    }

    public void Hit()
    {
        animator.SetTrigger(HitHash);
    }

    public void Die()
    {
        animator.SetBool(DeadHash, true);
    }

    public void Win()
    {
        animator.SetTrigger(WinHash);
    }
}