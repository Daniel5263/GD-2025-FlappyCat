using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isGameOver = false;

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
        if (!isGameOver)
        {
            isGameOver = true;
        }

        Time.timeScale = 0f;
    }
}