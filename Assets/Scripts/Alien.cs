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
    bool ok = false;

    // Start is called before the first frame update
    void Start()
    {
        // transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    // George take a look at using out of bounds exception handling
    /*
     * while (!ok7) {
                            try {
                                item = items.get(in.nextInt() - 1);
                                ok7 = true;
                            } catch (IndexOutOfBoundsException e) {
                                System.out.println("Please choose from the following options");
                                System.out.println(items.toString());
                                in.nextLine();
                            } catch (InputMismatchException e) {
                                System.out.println("Please choose from the following options");
                                System.out.println(items.toString());
                                in.nextLine();
                            }
    }
     */
    void Update()
    {
        Debug.Log("First Call " + waypointIndex);
        while (!ok)
        {
            try
            {
                var wayPointStart = waypoints[0].transform.position.x;
                var wayPointEnd = waypoints[1].transform.position.x;
            } catch (System.IndexOutOfRangeException e)
            {
                Debug.Log("Caught!");
            }
        }
        Debug.Log("Call after define waypointend " + waypointIndex);
        var targetPosition = waypoints[waypointIndex].transform.position.x;
        var movementThisFrame = moveSpeed * Time.deltaTime;
        Debug.Log("Call after target position and movement this Frame " + waypointIndex);
        Vector2 newTarget = new Vector2(targetPosition, transform.position.y);
        Debug.Log("Call after vector 2 newTarget made " +waypointIndex);
        // move alien towards target at all times
        transform.position = Vector2.MoveTowards(transform.position, newTarget, movementThisFrame);
        Debug.Log(waypointIndex);
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
