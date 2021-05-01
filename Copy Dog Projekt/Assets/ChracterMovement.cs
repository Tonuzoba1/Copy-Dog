using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
public class ChracterMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    public Slider progressSlider;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        SliderUpdate();

    }

    void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
        //a velocity változtatja a karakter sebességét. Ezt szorozzuk be az axissel így tudja merre menjen.

        if(x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            
        }
        
        if(x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        
        

    }

    void SliderUpdate()
    {
        
        progressSlider.value = (transform.position.x - 519) / 147 * 100;
        
        //Debug.Log(progressSlider.value);
    }

    //0 - 519
    //100 - 666
    // 622 - 587 = 147
    // 1% 0,35
}
