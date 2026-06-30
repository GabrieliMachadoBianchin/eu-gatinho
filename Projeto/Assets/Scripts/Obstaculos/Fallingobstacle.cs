using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FallingObstacle : MonoBehaviour
{
    public float tempoDeVida = 4f;

    private void Awake()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = true; 
    }

    private void Start()
    {
        Destroy(gameObject, tempoDeVida);
    }
}