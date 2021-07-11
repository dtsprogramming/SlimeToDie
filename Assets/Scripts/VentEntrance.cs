using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class VentEntrance : MonoBehaviour
{
    public Transform inside;
    public Collider2D outsideCollider;

    private GameObject player;
    private Animator anim;

    private bool canEnter = false;

    // Player UI
    public TMP_Text entertext;

    // Start is called before the first frame update
    void Start()
    {
        entertext = GameManager.instance.VentText;
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canEnter == true)
        {
            //Debug.Log("Enter vent?");
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("Key press detected, activating now!");
                player = GameObject.FindGameObjectWithTag("Player");
                StartCoroutine(Wait());
            }
        }
        else
        {

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
            entertext.text = "";
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            entertext.text = "Press E to enter vent.";
        }
    }

    void EnterVentAnim()
    {
        anim.Play("PlayerVentEnter");
    }

    IEnumerator Wait()
    {
        EnterVentAnim();
        FindObjectOfType<AudioManager>().Play("Vent");
        yield return new WaitForSeconds(1);
        player.GetComponent<Transform>().position = inside.transform.position;
    }
}
