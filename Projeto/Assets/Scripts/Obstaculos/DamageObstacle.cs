using UnityEngine;

public class DamageObstacle : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        PlayerHealth health =
            collision.gameObject.GetComponent<PlayerHealth>();

        if (health != null)
            health.TakeDamage(damage);
    }
}