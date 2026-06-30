using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance;

    public bool GameEnded { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void GameOver()
    {
        if (GameEnded)
            return;

        GameEnded = true;

        Debug.Log("GAME OVER");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Invoke(nameof(RestartLevel), 3f);
    }

    public void Win()
    {
        if (GameEnded)
            return;

        GameEnded = true;

        Debug.Log("YOU WIN");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}