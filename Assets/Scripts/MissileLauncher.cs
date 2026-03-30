// MissileLauncher.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Efe Esen | Student ID: 220337022
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    private GameObject activeMissile;

    public GameObject Launch(Transform target)
    {
        // TODO Task 3: instantiate and return missile
        return null;
    }

    public void DestroyActiveMissile()
    {
        // TODO Task 3: destroy active missile
        if (activeMissile != null)
        {
            Destroy(activeMissile);
            activeMissile = null;
        }
    }
}