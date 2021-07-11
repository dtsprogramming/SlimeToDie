using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    // Affect movement values
    [Header("Movement")]
    [SerializeField] private GameObject playerObject;
    [SerializeField] private int moveSpeed;

    // Affect jump values
    [Header("Jump")]
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    [SerializeField] private Transform feetPos;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] [Range(0, 100)] private float jumpVelocity;

    private float checkRadius;
    private bool isGrounded;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

    #endregion Variables

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CheckGrounded();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HorizontalMove();
        Jump();
    }

    #endregion Unity Methods

    #region User-defined Methods

    // Method to define horizontal movement and sprite orientation
    void HorizontalMove()
    {
        // Checks if the horizontal input is greater than 0
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            // Sets the player's rigidbody velocity
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            // Flips the spriterenderer to face right
            sr.flipX = false;
        }
        // Checks if the horizontal input is less than 0
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            // Sets the player's rigidbody velocity with negative move speed
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            // Flips the spriterenderer to face left
            sr.flipX = true;
        }
        // Runs if there is no movement input
        else
        {
            // Sets the player's rigidbody velocity to 0
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }

    // Method to define jump functionality
    void Jump()
    {
        // Checks if the jump button has been pressed
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Sets the vertical velocity
            rb2d.velocity = Vector2.up * jumpVelocity;
        }

        // Checks if the player's 'y' velocity is less than or equal to 0
        if (rb2d.velocity.y <= 0)
        {
            // Sets the 'y' velocity based on gravity and the fall multiplier
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        // Checks if the player's 'y' velocity is greater than 0 and the jump button is released
        else if (rb2d.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            // Sets the 'y' velocity based on gravity and the lowJumpMultiplier
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
    }

    #endregion User-defined Methods
}
