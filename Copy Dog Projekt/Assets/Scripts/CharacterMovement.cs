using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    private CharacterCombat charComb;

    //meat counter 
    public int meatGetSpeed;
    public float meatValue;


    public Slider progressSlider;
    public Slider meatSlider;
    public Text meatCounter;

    public Slider hpSlider;
    public Slider mpSlider;

    public TextMeshProUGUI hpCounter;
    public TextMeshProUGUI mpCounter;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        charComb = GetComponent<CharacterCombat>();

        meatValue = 0;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        SliderUpdate();
        MeatUpdate();

        

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
        //frissíti a hős értékeit
        progressSlider.value = (transform.position.x - 519) / 89 * 100;
        hpSlider.value = charComb.heroHealth;
        mpSlider.value = charComb.heroMana;

        hpCounter.text = charComb.heroHealth.ToString();
        mpCounter.text = charComb.heroMana.ToString();

        //Debug.Log(progressSlider.value);
    }

    void MeatUpdate()
    {
        if (Input.GetKeyDown("q"))
        {
            meatValue += 30;
        }

        meatValue += Time.deltaTime * meatGetSpeed;
        //Debug.Log(meatSlider.value);
        meatSlider.value = meatValue;
        int meatInt = Mathf.RoundToInt(meatValue);

        meatCounter.text = meatInt.ToString();

    }

    //0 - 519
    //100 - 608
    // 622 - 587 = 147
    // 1% 0,35
}
