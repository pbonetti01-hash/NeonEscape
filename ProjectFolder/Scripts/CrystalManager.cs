using UnityEngine;
using TMPro;

public class CrystalManager : MonoBehaviour
{
    public static CrystalManager Instance;

    public int currentCrystals = 0;
    public int expectedCrystals = 20;

    public TextMeshProUGUI currentText;
    public TextMeshProUGUI expectedText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddCrystal()
    {
        currentCrystals++;
        UpdateUI();
    }

    public bool ReachedGoal()
    {
        return currentCrystals >= expectedCrystals;
    }

    void UpdateUI()
    {
        currentText.text = currentCrystals.ToString();
        expectedText.text = expectedCrystals.ToString();
    }
}