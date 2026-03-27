using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverUI;
    public AudioSource musicSource;

    private bool isGameOver = false;

    void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        Time.timeScale = 0f;

        if (musicSource != null)
            musicSource.Stop();

        if (gameOverUI != null)
            gameOverUI.SetActive(true);
    }
}