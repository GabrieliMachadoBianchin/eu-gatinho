using UnityEngine;

public class DamageObstacle : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (health != null)
        {
            Debug.Log("Tomou dano!");

            health.TakeDamage(damage);
        }
    }
}