using UnityEngine;

public class KillOportunityCollider : MonoBehaviour
{
    bool canDestroy = false;

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
        if (Input.GetMouseButtonDown(0) && canDestroy)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
