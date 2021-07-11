using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalDoor : MonoBehaviour
{
    public int SlimeNeededToOpen;

    private SpriteRenderer renderer;
    public GameObject cubeCollision;
    private TMP_Text hintText;

    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        hintText = GameManager.instance.VentText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && GameManager.instance.slimeballs == SlimeNeededToOpen)
        {
            OpenDoor();
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && GameManager.instance.slimeballs == SlimeNeededToOpen)
        {
            CloseDoor();
        }

        hintText.text = "";
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && GameManager.instance.slimeballs != SlimeNeededToOpen)
        {
            hintText.text = "You need " + SlimeNeededToOpen + " to open this door.";
        }
    }

    void OpenDoor()
    {
        // works but disables trigger box that is needed
        // gameObject.SetActive(false);

        // disable sprite renederer and box collision
        renderer.enabled = false;
        cubeCollision.SetActive(false);
    }

    void CloseDoor()
    {
        // gameObject.SetActive(true);
        // enable sprite renederer and box collision
        renderer.enabled = true;
        cubeCollision.SetActive(true);
    }
}
