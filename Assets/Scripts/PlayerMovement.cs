using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private GameObject playerObject;
    [SerializeField] private int moveSpeed;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * moveSpeed;
    }
}
