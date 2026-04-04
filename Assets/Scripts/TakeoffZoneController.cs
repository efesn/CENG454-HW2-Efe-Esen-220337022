// TakeoffZoneController.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Efe Esen | Student ID: 220337022
using UnityEngine;

public class TakeoffZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        examManager.SetTakenOff();
    }
}