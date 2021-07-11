using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.slimeballs++;
            //Debug.Log("Slimeballs " + GameManager.instance.slimeballs);
            Destroy(this.gameObject);
        }
    }
}
