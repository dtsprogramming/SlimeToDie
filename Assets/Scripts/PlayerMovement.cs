using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private GameObject playerObject;
    [SerializeField] private int moveSpeed;

    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            sr.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            sr.flipX = true;
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
        }
    }
}
