using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class KillOportunityCollider : MonoBehaviour
{
    bool canDestroy = false;

    // Player UI
    public TMP_Text entertext;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log("collided");
            canDestroy = true;
            Debug.Log(canDestroy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log("Exit");
            canDestroy = false;
            Debug.Log(canDestroy);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canDestroy)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    void Start()
    {
        entertext = GameManager.instance.VentText;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            entertext.text = "Press E to assassinate.";
        }
    }
}

