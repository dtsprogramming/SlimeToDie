using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingCollide : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb2d;
    private SpriteRenderer renderer;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ceiling")
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        anim.Play("AlienDeath");
        rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
        gameObject.GetComponent<AINavigation>().enabled = false;
        renderer.flipY = true;
        gameObject.GetComponent<VelocityChecker>().DisableLights();
        yield return new WaitForSeconds(3);
        Destroy(transform.parent.gameObject);
    }
}
