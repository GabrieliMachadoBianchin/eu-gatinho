using UnityEngine;

public class FallingObstacleSpawner : MonoBehaviour
{
    [Header("Obstaculo")]
    public GameObject obstaculoPrefab;

    [Header("Spawn")]
    public float intervalo = 2f;
    public Transform pontoDeSpawn; 

    private float tempoDecorrido;

    private void Update()
    {
        tempoDecorrido += Time.deltaTime;

        if (tempoDecorrido >= intervalo)
        {
            tempoDecorrido = 0f;
            Spawnar();
        }
    }

    private void Spawnar()
    {
        if (obstaculoPrefab == null)
            return;

        Vector3 posicao = pontoDeSpawn != null ? pontoDeSpawn.position : transform.position;

        Instantiate(obstaculoPrefab, posicao, obstaculoPrefab.transform.rotation);
    }
}