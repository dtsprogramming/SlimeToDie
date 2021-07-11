using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityChecker : MonoBehaviour
{
    [SerializeField] public GameObject objLeft1;
    [SerializeField] public GameObject objLeft2;
    [SerializeField] public GameObject objRight1;
    [SerializeField] public GameObject objRight2;
    float pos;
    float velocity;
    private void Awake()
    {
        pos = transform.position.x;
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
        }
        else if (velocity > 0)
        {
            objLeft1.SetActive(false);
            objLeft2.SetActive(false);
            objRight1.SetActive(true);
            objRight2.SetActive(true);
        }
    }
}
