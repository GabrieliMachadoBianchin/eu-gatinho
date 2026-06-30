using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private string currentAnimation;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Play(string animationName)
    {
        if (currentAnimation == animationName)
            return;

        currentAnimation = animationName;

        animator.CrossFade(animationName, 0.15f);
    }

    public void UpdateMovement(float speed, bool grounded)
    {
        if (!grounded)
        {
            Play("fly");
            return;
        }

        if (speed < 0.1f)
        {
            Play("idle");
            return;
        }

        if (Input.GetKey(KeyCode.LeftShift))
            Play("run");
        else
            Play("walk");
    }

    public void Jump()
    {
        Play("jump");
    }

    public void Hit()
    {
        Play("hit");
    }

    public void Die()
    {
        Play("die");
    }
}