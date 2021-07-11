// George
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Destroy(GameObject.Find("Player"));
        }
    }
}
