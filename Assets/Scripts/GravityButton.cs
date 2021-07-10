using UnityEngine;

public class GravityButton : MonoBehaviour
{
    // Script for Gravity button, which is a prefab. Calls a function in gamemanager.

    private bool GravityIsFlipped;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
            // FlipGravity();
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
}
