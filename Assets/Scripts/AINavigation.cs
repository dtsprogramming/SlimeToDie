using UnityEngine;

public class AINavigation : MonoBehaviour
{
    #region Variables

    [Header("Enemy Object")]
    [SerializeField] private GameObject enemy;
    [SerializeField] private float moveSpeed;

    [Header("Waypoints")]
    [SerializeField] private Transform[] waypoints;

    private Vector2 targetPosStart;
    private Vector2 targetPosEnd;
    private bool isWaypointStart = true;
    private Transform tf;

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        // Stores the enemies Transform value.
        tf = enemy.GetComponent<Transform>();
    }
    private void Update()
    {
        NavigateWaypoints();
    }

    #endregion Unity Methods

    #region User-defined Methods

    // Method to swap between two waypoints
    void NavigateWaypoints()
    {
        // Set targets based on waypoint 'x' and enemy 'y'.
        targetPosStart = new Vector2(waypoints[1].transform.position.x, tf.position.y);
        targetPosEnd = new Vector2(waypoints[0].transform.position.x, tf.position.y);

        // Checks if the current waypoint is the starting waypoint.
        if (isWaypointStart)
        {
            // Sets the enemy position to the next waypoint.
            tf.position = Vector2.MoveTowards(tf.position, targetPosEnd, moveSpeed * Time.deltaTime);

            // Checks if the enemies 'x' value is equal to the waypoint 'x' value.
            if (tf.position.x == targetPosEnd.x)
            {
                // Sets the waypoint one boolean to false.
                isWaypointStart = false;
            }
        }
        // Runs if the waypoint one boolean is false
        else
        {
            // Sets the enemy position back to the first waypoint
            tf.position = Vector2.MoveTowards(tf.position, targetPosStart, moveSpeed * Time.deltaTime);

            // Checks if the enemies 'x' value is the same as the starting waypoint 'x' value.
            if (tf.position.x == targetPosStart.x)
            {
                // Sets the waypoint start boolean to true.
                isWaypointStart = true;
            }
        }
    }

    #endregion User-defined Methods
}
