using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public static HealthUI Instance;

    public TMP_Text livesText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateLives(7);
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }
}