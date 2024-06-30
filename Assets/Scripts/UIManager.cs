using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOver;
    [SerializeField] private GameObject Wave;
    [SerializeField] private GameObject Health;
    public void GameOverFunc()
    {
        gameOver.SetActive(true);
    }

    public IEnumerator WavePass()
    {
        Wave.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Wave.SetActive(false);

    }
    public IEnumerator HealthEarned()
    {
        Health.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Health.SetActive(false);

    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("menu");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
    }
    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
