using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCombat : MonoBehaviour
{
    public int heroHealth;
    public int heroMana;

     private int maxHealth = 100;
     private int maxMana = 100;

    public GameObject GameOverPanel;

    void Start()
    {
        heroHealth = maxHealth;
        heroMana = maxMana;
    }


    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        heroHealth -= (damage);
        Debug.Log("Megütötték a hőst!");

        GameOver();
    }

    public void GameOver()
    {
        if (heroHealth <= 0)
        {
            //megállítja az időt és megjeleníti a gameover panelt
            Time.timeScale = 0;
            Debug.Log("A hős halott");
            GameOverPanel.SetActive(true);
        }
    }

}
