using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [Header("Destino")]
    public Transform destino; 

    [Header("Opcoes")]
    public float cooldown = 0.5f; // evita ficar teleportando ida e volta sem parar
    public bool manterRotacao = true; // se false, o player tambem copia a rotacao do destino

    private float proximoUsoPermitido;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (destino == null)
        {
            Debug.LogWarning("Teleporter sem destino definido em " + gameObject.name);
            return;
        }

        if (Time.time < proximoUsoPermitido)
            return;

        Rigidbody rb = other.attachedRigidbody;

        if (rb != null)
        {
            // usando MovePosition/posicao direta no Rigidbody evita problemas de colisao
            rb.position = destino.position;

            if (!manterRotacao)
                rb.rotation = destino.rotation;
        }
        else
        {
            other.transform.position = destino.position;

            if (!manterRotacao)
                other.transform.rotation = destino.rotation;
        }

        proximoUsoPermitido = Time.time + cooldown;
    }
}