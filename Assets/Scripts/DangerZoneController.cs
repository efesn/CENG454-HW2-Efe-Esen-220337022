// DangerZoneController.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Efe Esen | Student ID: 220337022
using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Show warning immediately
        examManager.EnterDangerZone();

        // Start delayed missile launch
        activeCountdown = StartCoroutine(MissileCountdown(other.transform));
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Cancel countdown if still running
        if (activeCountdown != null)
        {
            StopCoroutine(activeCountdown);
            activeCountdown = null;
        }

        // Destroy active missile and clear HUD
        missileLauncher.DestroyActiveMissile();
        examManager.ExitDangerZone();
    }

    private IEnumerator MissileCountdown(Transform target)
    {
        yield return new WaitForSeconds(missileDelay);
        missileLauncher.Launch(target);
    }
}