// George
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalSight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemies facing will be alerted.");
    }
}
