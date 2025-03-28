using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject gameOverCanvas;

    public AudioClip clickSound;
    public float delayBeforeReload = 0.3f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        if (clickSound != null)
        {
            AudioManager.instance.PlaySound(clickSound);
        }

        StartCoroutine(RestartAfterDelay());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private System.Collections.IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeReload);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}