// George
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalSight : MonoBehaviour
{
    static int count = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemies facing will be alerted.");
        Debug.Log("Value returned" + gameObject.GetComponent<ExtendedEnemySight>().returnCollision());
        count++;
        Debug.Log(count);
        if (gameObject.GetComponent<ExtendedEnemySight>().returnCollision() == true) //learned how to get functions from other classes
        {
            Destroy(GameObject.Find("Player"));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited light, Enemies have normal vision");
    }
}
