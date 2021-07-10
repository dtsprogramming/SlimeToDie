using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedEnemySight : MonoBehaviour
{
    bool collide = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        collide = true;
        Debug.Log("Entered extended vision. collide = " + collide);
        Debug.Log("returnCollision = " + collide);
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
