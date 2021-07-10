using UnityEngine;

public class CamFollow : MonoBehaviour
{
    #region Variables

    [Header("Object to follow")] // Variable for follow target
    // Stores a game object called player
    [SerializeField] private GameObject player;

    [Header("Cam offset values")] // Variables for camera offsets
    // Stores a time offset
    [SerializeField] private float timeOffset;
    // Stores a position offset
    [SerializeField] private Vector2 posOffset;
    // Stores a camera velocity
    private Vector3 velocity;

    [Header("Camera Boundaries")] // Variables for camera boundaries
    // Stores the left boundary
    [SerializeField] private float leftLimit;
    // Stores the right boundary
    [SerializeField] private float rightLimit;
    // Stores the top boundary
    [SerializeField] private float topLimit;
    // Stores the bottom boundary
    [SerializeField] private float bottomLimit;

    #endregion Variables

    #region Unity Methods

    // Updates late with calculated values
    void LateUpdate()
    {
        // Sets the cameras current position to startPos
        Vector3 startPos = transform.position;

        // Sets the player's current position to the endPos
        Vector3 endPos = player.transform.position;

        // Sets offset values based on the player's Vectors
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        // Manually set to a position in front of all scene elements
        endPos.z = -30;

        // Sets the cameras position to the new Vector3, with a smooth transition over time
        // Passes in the start position, end positon, speed of the camera, and time delay
        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);

        // Sets the new camera position
        transform.position = new Vector3
        (
            // Clamps the camera transform for the x axis to the left and right limits
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            // Clamps the camera transform for the y axis to the top and bottom limits
            Mathf.Clamp(transform.position.y, topLimit, bottomLimit),
            // The Z transform doesn't need to change
            transform.position.z
        );
    }

    #endregion Unity Methods
}
