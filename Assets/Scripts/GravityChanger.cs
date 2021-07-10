using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    // Add this script to any character or enemy you want affected by gravity
    // gravity for everyone can be changed in the gamemananger

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = GameManager.instance.GravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.gravityScale = GameManager.instance.GravityScale;
    }
}
