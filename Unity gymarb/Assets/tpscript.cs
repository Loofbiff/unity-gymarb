using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    // Assign the target teleport destination in the Inspector
    public Transform teleportDestination;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            if (teleportDestination != null)
            {
                // Ensure teleport works by logging and moving the player
                Debug.Log("Player teleported to: " + teleportDestination.position);
                other.transform.position = teleportDestination.position;

                // Optional: Reset player velocity if it has a Rigidbody
                Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
                if (playerRigidbody != null)
                {
                    playerRigidbody.velocity = Vector3.zero;
                }
            }
            else
            {
                Debug.LogError("Teleport destination is not assigned in the Inspector!");
            }
        }
    }
}
