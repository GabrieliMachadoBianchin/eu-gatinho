using UnityEngine;

public class WinZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (InGameManager.Instance != null)
            InGameManager.Instance.Win();
    }
}