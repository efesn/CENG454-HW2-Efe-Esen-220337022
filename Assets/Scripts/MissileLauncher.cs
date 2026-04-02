// MissileLauncher.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Efe Esen | Student ID: 220337022
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private AudioSource launchAudioSource;
    private GameObject activeMissile;

    public GameObject Launch(Transform target)
    {
        // Task 3-A: instantiate missile at launch point
        activeMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);

        // Task 3-B: give missile its target
        MissileHoming homing = activeMissile.GetComponent<MissileHoming>();
        if (homing != null)
            homing.SetTarget(target);

        // Task 3-C: play launch audio
        if (launchAudioSource != null)
            launchAudioSource.Play();

        return activeMissile;
    }

    public void DestroyActiveMissile()
    {
        // TODO (Task 3-D): destroy the current missile safely if one exists 
        if (activeMissile != null)
        {
            Destroy(activeMissile);
            activeMissile = null;
        }
    }
}