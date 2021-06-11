using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public bool isCollidedwEnemy;

    public GameObject endOfMap;

    public AllyCombat allyCombatScript;

    void Start()
    {
        endOfMap = GameObject.Find("EndOfMap");
        allyCombatScript = gameObject.GetComponent<AllyCombat>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);        

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //ha elér a map szélére meghal
        if(collision.collider.tag == "EndOfMap")
        {
            Destroy(gameObject);
        }

        //stop - harcnál megállítja a karaktert és jelez az 'isCollidedwEnemy' vel h ütközött ezt veszi át a combat script
        if (collision.collider.tag == "Enemy" && !isCollidedwEnemy)
        {
            Debug.Log("Fight!");
            speed = 0;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            isCollidedwEnemy = true;
        }
 
        

    }

    //ha elhagyja/megöli az ellenséget akkor továbbmegy
    public void OnCollisionExit2D(Collision2D collision)
    {
            MoveForward();
        
    }


    void MoveForward()
    {
         
        speed = 3;
        isCollidedwEnemy = false;
        
    }
}
