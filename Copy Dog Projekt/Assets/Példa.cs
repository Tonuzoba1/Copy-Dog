using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Példa : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    [SerializeField] private float jumpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
        //a velocity változtatja a karakter sebességét. Ezt szorozzuk be az axissel így tudja merre menjen.

        if (x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }

        if (x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector3(0, jumpSpeed, 0));
    }
}
