// FlightExamManager.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Efe Esen | Student ID: 220337022
using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;

    private bool hasTakenOff = false;
    private bool threatCleared = false;
    private bool missionComplete = false;

    public bool ThreatCleared => threatCleared;

    public void SetTakenOff()
    {
        if (hasTakenOff) return;
        hasTakenOff = true;
        missionText.text = "Mission: Enter the Danger Zone";
    }

    public void EnterDangerZone()
    {
        statusText.text = "Entered a Dangerous Zone!";
        missionText.text = "Mission: Escape the Danger Zone!";
    }

    public void ExitDangerZone()
    {
        threatCleared = true;
        statusText.text = "You escaped the Danger Zone!";
        missionText.text = "Mission: Land Safely";
    }

    public void MissionFailed()
    {
        threatCleared = false;
        statusText.text = "Mission Failed! Try again.";
        missionText.text = "Mission: Take Off";
    }

    public void TryCompleteMission()
    {
        if (!hasTakenOff || !threatCleared)
        {
            statusText.text = "You must clear the threat first!";
            return;
        }

        missionComplete = true;
        statusText.text = "Mission Complete!";
        missionText.text = "You landed safely. Well done!";
    }
}