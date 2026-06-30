using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance;

    [Header("UI")]
    public GameObject gameOverPanel;
    public GameObject winPanel;

    [Header("Cenas")]
    public string mainMenuSceneName = "Menu"; 

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

        Time.timeScale = 0f; // congela a tela

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    public void Win()
    {
        if (GameEnded)
            return;

        GameEnded = true;

        Debug.Log("YOU WIN");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f; // congela a tela

        if (winPanel != null)
            winPanel.SetActive(true);
    }

    // chamado pelo botao "Reiniciar" do painel de Game Over / Win
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // chamado pelo botao "Menu Inicial" do painel de Game Over / Win
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuSceneName);
    }
}

/*using UnityEngine;
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
}*/