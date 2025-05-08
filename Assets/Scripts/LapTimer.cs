using UnityEngine;
using TMPro;

public class LapTimer : MonoBehaviour
{
    public int totalLaps = 3;
    private int currentLap = 0;
    private bool raceFinished = false;

    [Header("UI Reference")]
    public TextMeshProUGUI lapText;

    void Start()
    {
        UpdateLapUI();
    }

    public void CompleteLap()
    {
        if (raceFinished) return;

        currentLap++;

        if (currentLap >= totalLaps)
        {
            raceFinished = true;
            lapText.text = $"Finished!";
            return;
        }

        UpdateLapUI();
    }

    void UpdateLapUI()
    {
        lapText.text = $"Lap: {currentLap + 1} / {totalLaps}";
    }
}
