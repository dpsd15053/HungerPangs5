using UnityEngine;

public class MovingBridge : MonoBehaviour
{
    [SerializeField] private Transform rotatingEnd;    // End of the bridge that rotates
    [SerializeField] private float rotationSpeed = 45f; // Speed of rotation in degrees per second
    [SerializeField] private float rotationRange = 45f; // Maximum rotation angle in degrees

    private void Update()
    {
        RotateBridge();
    }

    private void RotateBridge()
    {
        // Calculate the rotation angle based on the sine function to make it oscillate
        float angle = rotationRange * Mathf.Sin(Time.time * rotationSpeed * Mathf.Deg2Rad);

        // Set the rotation of the rotating end of the bridge
        rotatingEnd.localRotation = Quaternion.Euler(0f, 0f, angle);
    }
}
