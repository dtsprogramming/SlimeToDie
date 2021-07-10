// George
// todo: sight sticks to alien, flips when alien turns
// todo: alien moves back and forth
// todo: need a systme to set how far back and forth alien can go, perhaps serialize min and max x position.
// todo: kill player if player collides with sight or alien
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2f;
    int waypointIndex = 1;

    // Start is called before the first frame update
    void Start()
    {
        // transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var wayPointStart = waypoints[0].transform.position.x;
        var wayPointEnd = waypoints[1].transform.position.x;

        var targetPosition = waypoints[waypointIndex].transform.position.x;
        var movementThisFrame = moveSpeed * Time.deltaTime;

        Vector2 newTarget = new Vector2(targetPosition, transform.position.y);

        // move alien towards target at all times
        transform.position = Vector2.MoveTowards(transform.position, newTarget, movementThisFrame);

        // check shit idk
        if (transform.position.x == targetPosition)
        {
            if (waypointIndex == 1)
            {
                waypointIndex--;
            }
            else if (waypointIndex == 0)
            {
                waypointIndex++;
            }
        }
    }
}
