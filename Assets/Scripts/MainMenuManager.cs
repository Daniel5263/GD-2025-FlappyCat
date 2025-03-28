using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioClip clickSound;
    public float delayBeforeLoad = 0.3f;

    public void StartGame()
    {
        if (clickSound != null)
        {
            AudioManager.instance.PlaySound(clickSound);
        }

        StartCoroutine(LoadGameAfterDelay());
    }

    private System.Collections.IEnumerator LoadGameAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene("MainGame");
    }
}
