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
        Physics2D.IgnoreLayerCollision(12, 12);
        Physics2D.IgnoreLayerCollision(12, 9);
        //Physics2D.IgnoreLayerCollision(12, 14);

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
        if(collision.collider.tag == "Ground")
        {
            Debug.Log("földet ért");
        }


        if (collision.collider.tag == "EndOfMap")
        {
            Destroy(gameObject);
        }

        //stop
        if ((collision.collider.tag == "Ally" || collision.collider.tag == "Player") && !isCollidedwAlly)
        {
            Debug.Log("Az ellenség megállt ");
            speed = 0;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            isCollidedwAlly = true;
        }
    }




    public void OnCollisionExit2D(Collision2D collision)
    {
        MoveForward();

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ally" && !isCollidedwAlly)
        {

            speed = 0;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            isCollidedwAlly = true;
        }
    }


    void MoveForward()
    {

        speed = 3;
        isCollidedwAlly = false;

    }
}
