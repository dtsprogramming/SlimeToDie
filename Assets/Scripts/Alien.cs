// George
// todo: sight sticks to alien, flips when alien turns
// todo: alien moves back and forth
// todo: need a systme to set how far back and forth alien can go, perhaps serialize min and max x position.
// todo: kill player if player collides with sight or alien
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2f;
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        waypointIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        var wayPointStart = waypoints[0].transform.position;
        var wayPointEnd = waypoints[1].transform.position;
        var targetPosition = waypoints[waypointIndex].transform.position;
        var movementThisFrame = moveSpeed * Time.deltaTime;
        if(transform.position == wayPointEnd)
        {
            targetPosition = wayPointStart;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
        }
        else
        {
            targetPosition = wayPointEnd;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
        }
    }

}
