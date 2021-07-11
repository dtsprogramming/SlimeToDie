using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sight")
        {
            Debug.Log("Collision");
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Square").GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<PlayerMovement>().enabled = false;

            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("Square").GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<PlayerMovement>().enabled = true; 
        gameObject.GetComponent<Rigidbody2D>().bodyType.Equals("Dynamic");
        transform.position = GameObject.Find("Respawn").transform.position;
    }
}
