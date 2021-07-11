using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityCheckerRobot : MonoBehaviour
{
    [SerializeField] public GameObject objLeft1;
    [SerializeField] public GameObject objRight1;
    float pos;
    float velocity;

    private SpriteRenderer renderer;

    private void Awake()
    {
        pos = transform.position.x;
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        velocityCheck();
    }

    private void velocityCheck()
    {
        velocity = (transform.position.x - pos) / Time.deltaTime;
        pos = transform.position.x;
        //Debug.Log(velocity);
        if (velocity <= 0)
        {
            objLeft1.SetActive(true);
            objRight1.SetActive(false);
            renderer.flipX = false;
        }
        else if (velocity > 0)
        {
            objLeft1.SetActive(false);
            objRight1.SetActive(true);
            renderer.flipX = true;
        }
    }
}
