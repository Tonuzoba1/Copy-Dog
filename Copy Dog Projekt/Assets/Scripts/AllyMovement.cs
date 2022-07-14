using UnityEngine;

public class AllyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float maxSpeed;
    public bool isCollidedwEnemy;

    public GameObject endOfMap;

    public AllyCombat allyCombatScript;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(13, 13);
        Physics2D.IgnoreLayerCollision(13, 9);

        endOfMap = GameObject.Find("EndOfMap");
        allyCombatScript = gameObject.GetComponent<AllyCombat>();
        rb = GetComponent<Rigidbody2D>();
        speed = maxSpeed;

        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
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
            speed = 0;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            isCollidedwEnemy = true;
        }

        if (collision.collider.tag == "Fort" && !isCollidedwEnemy)
        {
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

    public void EnemyInRange()
    {
        speed = 0;
        rb.velocity = new Vector2(speed, rb.velocity.y);
        isCollidedwEnemy = true;
    }

    public void MoveForward()
    {       
        speed = maxSpeed;
        isCollidedwEnemy = false;    
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy" && !isCollidedwEnemy)
        {
            Debug.Log("A társad még egyhelyben áll!");
            speed = 0;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            isCollidedwEnemy = true;
        }

        if (collision.collider.tag == "Fort" && !isCollidedwEnemy)
        {
            Debug.Log("A társad megállt");
            speed = 0;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            isCollidedwEnemy = true;
        }
    }
}
