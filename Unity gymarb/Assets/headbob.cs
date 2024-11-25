using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public Transform cameraTransform; // Reference to the camera
    public float bobFrequency = 2f;   // Speed of bobbing
    public float bobAmplitude = 0.1f; // Height of bobbing
    public float bobSmoothing = 10f;  // Smoothing factor

    private float bobTimer = 0f;      // Timer for the sine wave
    private Vector3 initialPosition; // Initial camera position

    void Start()
    {
        // Save the initial position of the camera
        if (cameraTransform == null)
            cameraTransform = transform;

        initialPosition = cameraTransform.localPosition;
    }

    void Update()
    {
        // Check if the player is moving
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Arrow keys
        float vertical = Input.GetAxis("Vertical");   // W/S or Arrow keys
        bool isMoving = Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f;

        if (isMoving)
        {
            // Increment timer based on movement
            bobTimer += Time.deltaTime * bobFrequency;

            // Calculate bobbing offset
            float offsetY = Mathf.Sin(bobTimer) * bobAmplitude;

            // Apply bobbing to the camera's local position
            Vector3 targetPosition = new Vector3(initialPosition.x, initialPosition.y + offsetY, initialPosition.z);
            cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, targetPosition, Time.deltaTime * bobSmoothing);
        }
        else
        {
            // Reset timer and smoothly return to initial position when idle
            bobTimer = 0f;
            cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, initialPosition, Time.deltaTime * bobSmoothing);
        }
    }
}
