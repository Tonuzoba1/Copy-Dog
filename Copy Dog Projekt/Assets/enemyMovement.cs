using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    public bool isCollidedwAlly = false;

    public GameObject endOfMap;

    public EnemyCombat enemyCombatScript;

    

    void Start()
    {
        enemyCombatScript = gameObject.GetComponent<EnemyCombat>();
        endOfMap = GameObject.Find("EndOfMap");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        //Debug.Log(collision.collider.name);
        if (collision.collider.tag == "EndOfMap")
        {
            Destroy(gameObject);
        }

        //stop
        if ((collision.collider.tag == "Ally" || collision.collider.tag == "Player") && !isCollidedwAlly)
        {
            Debug.Log("Fight!");
            speed = 0;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            isCollidedwAlly = true;
        }
    }




    public void OnCollisionExit2D(Collision2D collision)
    {
        MoveForward();

    }


    void MoveForward()
    {

        speed = 3;
        isCollidedwAlly = false;

    }
}
