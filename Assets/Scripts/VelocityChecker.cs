using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class VelocityChecker : MonoBehaviour
{
    [SerializeField] public GameObject objLeft1;
    [SerializeField] public GameObject objLeft2;
    [SerializeField] public GameObject objRight1;
    [SerializeField] public GameObject objRight2;
    float pos;
    float velocity;

    private SpriteRenderer renderer;
    private Animator anim;

    private void Awake()
    {
        pos = transform.position.x;
        renderer = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
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
            objLeft2.SetActive(true);
            objRight1.SetActive(false);
            objRight2.SetActive(false);
            renderer.flipX = true;
        }
        else if (velocity > 0)
        {
            objLeft1.SetActive(false);
            objLeft2.SetActive(false);
            objRight1.SetActive(true);
            objRight2.SetActive(true);
            renderer.flipX = false;
        }
    }

    public void DisableLights()
    {
        Destroy(objLeft1);
        Destroy(objLeft2);
        Destroy(objRight1);
        Destroy(objRight2);
    }
}
