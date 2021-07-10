using UnityEngine;

public class ExtendedEnemySight : MonoBehaviour
{
    static bool collide = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collide = true;
            Debug.Log("Entered extended vision. collide = " + collide);
            Debug.Log("returnCollision = " + collide);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        collide = false;
        Debug.Log("Exited extended vision. collide = " + collide);
        returnCollision();
    }

    public bool returnCollision()
    {
        Debug.Log("returnCollision = " + collide);
        return collide;
    }
}
