using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using TMPro;

public class KillOportunityCollider : MonoBehaviour
{
    bool canDestroy = false;

    private GameObject player;
    private Animator anim;

    public Animator EnemyAnimator;

    // Player UI
    public TMP_Text entertext;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();

        entertext = GameManager.instance.VentText;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canDestroy)
        {
            StartCoroutine(Wait());
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log("collided");
            canDestroy = true;
            Debug.Log(canDestroy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log("Exit");
            canDestroy = false;
            Debug.Log(canDestroy);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            entertext.text = "Press E to assassinate.";
        }
    }

    void AttackAnim()
    {
        anim.Play("PlayerAttackEnemy");
    }

    IEnumerator Wait()
    {
        AttackAnim();
        yield return new WaitForSeconds(3);
        EnemyAnimator.Play("AlienDeath");
        yield return new WaitForSeconds(3);
        Destroy(transform.parent.gameObject);
    }
}

