using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    [Header("Rotacao")]
    public float velocidade = 90f; // graus por segundo
    public bool sentidoHorario = true;

    private void Update()
    {
        float direcao = sentidoHorario ? 1f : -1f;

        // gira em torno do eixo Y (rotacao horizontal)
        transform.Rotate(Vector3.up, velocidade * direcao * Time.deltaTime);
    }
}