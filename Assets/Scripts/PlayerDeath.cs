using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private Animator anim;
    private GameObject respawn;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        respawn = GameObject.FindGameObjectWithTag("Respawn");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sight")
        {
            Debug.Log("Collision");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {

        anim.Play("PlayerDeath");
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        transform.position = respawn.transform.position;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
}
