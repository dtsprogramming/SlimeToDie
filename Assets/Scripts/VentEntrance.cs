using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class VentEntrance : MonoBehaviour
{
    public Transform inside;
    public Collider2D outsideCollider;

    private GameObject player;

    private bool canEnter = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canEnter == true)
        {
            Debug.Log("Enter vent?");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Key press detected, activating now!");
                player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<Transform>().position = inside.transform.position;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canEnter = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canEnter = false;
        }
    }
}
