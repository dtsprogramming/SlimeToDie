using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOportunityCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
            Destroy(GameObject.Find("Alien")); 
    }
}
