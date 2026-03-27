using UnityEngine;
using TMPro;

public class TimeGameManager : MonoBehaviour
{
    public float timeLeft = 120f; // 2 minutos

    public TextMeshProUGUI timerText;

    [Header("Crystal System")]
    public int minCrystalIncrease = 20;
    public int maxCrystalIncrease = 50;

    private bool isRunning = true;

    void Update()
    {
        if (!isRunning) return;

        timeLeft -= Time.deltaTime;

        UpdateUI();

        if (timeLeft <= 0f)
        {
            CheckGoal();
        }
    }

    void CheckGoal()
    {
        isRunning = false;

        if (CrystalManager.Instance.currentCrystals < CrystalManager.Instance.expectedCrystals)
        {
            GameManager.Instance.GameOver();
        }
        else
        {
            NextRound();
        }
    }

    void NextRound()
    {
        // Reset tempo
        timeLeft = 120f;

        // Aumenta meta
        int extra = Random.Range(minCrystalIncrease, maxCrystalIncrease + 1);
        CrystalManager.Instance.expectedCrystals += extra;

        // Continua rodando
        isRunning = true;
    }

    void UpdateUI()
    {
        int seconds = Mathf.CeilToInt(timeLeft);
        int minutes = seconds / 60;
        int remainingSeconds = seconds % 60;

        timerText.text = minutes.ToString("00") + ":" + remainingSeconds.ToString("00");
    }
}