using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FortBehav : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    [SerializeField] private int damageLvl;

    //effectek
    [SerializeField] private ParticleSystem backSmoke;
    [SerializeField] private ParticleSystem frontSmoke;
    [SerializeField] private ParticleSystem backFire;
    [SerializeField] private ParticleSystem frontFire;
    //effectek vége

    //spriteok
    [SerializeField] private SpriteRenderer sr;

    [SerializeField] private Sprite state_0;
    [SerializeField] private Sprite state_1;
    [SerializeField] private Sprite state_2;
    [SerializeField] private Sprite state_3;
    [SerializeField] private Sprite state_4;
    //spriteok vége

    [SerializeField] private GameObject winPanel;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private GameObject hpSliderObject;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        damageLvl = 0;
        currentHealth = maxHealth;
        hpSlider.maxValue = maxHealth;
    }

    void Update()
    {

        if(currentHealth < maxHealth)
        {
            hpSliderObject.SetActive(true);

            if(currentHealth <= 0)
            {
            damageLvl = 4;
            }
            else if(currentHealth <= maxHealth * 0.25f)
            {
            damageLvl = 3;
            }
            else if(currentHealth <= maxHealth * 0.5f)
            {
            damageLvl = 2;
            }
            else if(currentHealth <= maxHealth * 0.75f)
            {
            damageLvl = 1;
            }


            switch (damageLvl)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        sr.sprite = state_1;
                        if (!backSmoke.isPlaying)
                        {
                            backSmoke.Play();
                        }
                        break;
                    }
                case 2:
                    {
                        sr.sprite = state_2;
                        if (!frontSmoke.isPlaying)
                        {
                            frontSmoke.Play();
                        }
                        break;
                    }
                case 3:
                    {
                        sr.sprite = state_3;
                        if (!backFire.isPlaying)
                        {
                            backFire.Play();
                        }
                        break;
                    }
                case 4:
                    {
                        sr.sprite = state_4;
                        if (!frontFire.isPlaying)
                        {
                            frontFire.Play();
                        }
                        break;
                    }
            }

        }
    }

    public void TakeDamage(float damage)
    {
        if(currentHealth <= 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            PlayerStats.playerCoins += 100;
            PlayerStats.reachedLevel++;

            winPanel.SetActive(true);
            hpSliderObject.SetActive(false);


        } else
        {
            currentHealth -= damage;
        }

        hpSlider.value = currentHealth;



    }
}
