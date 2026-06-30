using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;

    [Header("Paineis")]
    public GameObject pausePanel;
    public GameObject audioPanel; 

    [Header("Cenas")]
    public string mainMenuSceneName = "Menu";

    public bool IsPaused { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        // nao deixa pausar se o jogo ja acabou (Game Over / Win cuidam disso sozinhos)
        if (InGameManager.Instance != null && InGameManager.Instance.GameEnded)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        IsPaused = true;
        Time.timeScale = 0f;

        if (pausePanel != null)
            pausePanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        IsPaused = false;
        Time.timeScale = 1f;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        if (audioPanel != null)
            audioPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // chamado pelo botao "Reiniciar" do menu de pausa
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // chamado pelo botao "Menu Inicial" do menu de pausa
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void OpenAudioSettings()
    {
        if (audioPanel != null)
            audioPanel.SetActive(true);
    }

    public void CloseAudioSettings()
    {
        if (audioPanel != null)
            audioPanel.SetActive(false);
    }
}