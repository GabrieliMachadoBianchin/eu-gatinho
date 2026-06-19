using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Play clicado");

        SceneManager.LoadScene("Jogo");
    }

    public void ExitGame()
    {
        Debug.Log("Exit clicado");

        Application.Quit();
    }
}