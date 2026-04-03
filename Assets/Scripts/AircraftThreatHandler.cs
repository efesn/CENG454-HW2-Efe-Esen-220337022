// AircraftThreatHandler.cs 
using UnityEngine; 
 
public class AircraftThreatHandler : MonoBehaviour 
{ 
    [SerializeField] private Transform respawnPoint; 
    [SerializeField] private AudioSource hitAudioSource; 
    [SerializeField] private FlightExamManager examManager; 
 
    private Rigidbody rb; 
 
    void Start() 
    { 
        // TODO (Task 3-G): cache GetComponent<Rigidbody>() into 'rb' 
        rb = GetComponent<Rigidbody>();
    } 
 
    private void OnTriggerEnter(Collider other)
    {
        // Task 3-H: if missile hits aircraft, apply penalty
        if (!other.CompareTag("Missile")) return;

        // hit audio
        if (hitAudioSource != null)
            hitAudioSource.Play();

        // Notify mission manager
        examManager.MissionFailed();

        // Reset aircraft to respawn point
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;
    }
} 