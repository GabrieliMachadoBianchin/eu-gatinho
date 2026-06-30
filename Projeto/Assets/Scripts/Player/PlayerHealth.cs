using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerAnimation))]
public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 7;
    public float invulnerabilityTime = 1f;

    public int CurrentLives { get; private set; }

    private bool invulnerable;

    private PlayerAnimation playerAnimation;

    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        CurrentLives = maxLives;
    }

    public void TakeDamage(int damage)
    {
        if (invulnerable)
            return;

        CurrentLives -= damage;

        CurrentLives = Mathf.Max(CurrentLives, 0);

        HealthUI.Instance.UpdateLives(CurrentLives);

        playerAnimation.Hit();

        if (CurrentLives <= 0)
        {
            playerAnimation.Die();

            GetComponent<PlayerController>().enabled = false;

            InGameManager.Instance.GameOver();

            return;
        }

        StartCoroutine(Invulnerability());
    }

    public void Die()
    {
        CurrentLives = 0;

        HealthUI.Instance.UpdateLives(CurrentLives);

        playerAnimation.Die();

        GetComponent<PlayerController>().enabled = false;

        InGameManager.Instance.GameOver();
    }

    IEnumerator Invulnerability()
    {
        invulnerable = true;

        yield return new WaitForSeconds(invulnerabilityTime);

        invulnerable = false;
    }
}