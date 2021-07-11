using UnityEngine;

public class GravityButton : MonoBehaviour
{
    // Script for Gravity button, which is a prefab. Calls a function in gamemanager.

    private bool GravityIsFlipped;
    private GameObject player;
    private Animator anim;
    private SpriteRenderer renderer;

    public Sprite On;
    public Sprite Off;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.FlipGravity();
            GravityAnimation();
            // FlipGravity();

            // if true, make false etc
            // Flips player with Gravity
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().flipY == false)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().flipY = true;
            }
            else if (GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().flipY == true)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().flipY = false;
            }

            // Change sprite
            if (renderer.sprite.name == "Lever2")
            {
                FindObjectOfType<AudioManager>().Play("Switch");
                renderer.sprite = Off;
            }
            else if (renderer.sprite.name == "Lever")
            {
                FindObjectOfType<AudioManager>().Play("Switch");
                renderer.sprite = On;
            }
        }
    }

    private void FlipGravity()
    {
        if (player.GetComponent<Rigidbody2D>().gravityScale == 20)
        {
            player.GetComponent<Rigidbody2D>().gravityScale = -20;
        }
        else if (player.GetComponent<Rigidbody2D>().gravityScale == -20)
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 20;
        }
    }

    private void GravityAnimation()
    {
        anim.Play("PlayerGravityFlip");
    }
}
