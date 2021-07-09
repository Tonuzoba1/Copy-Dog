using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterCombat : MonoBehaviour
{
    public int heroHealth;
    public int heroMana;

    public int healthMultiplier;
    public int manaMultiplier;

    public int healthRegenMultiplier = 1;
    public int manaRegenMultiplier = 1;

    //public int regenSpeedMultiplier = 1;


    private int maxHealth = 100;
     private int maxMana = 100;

    public GameObject gameOverPanel;

    public int getDamage;
    public GameObject damagePopup;
    public Transform damagePopupPos;

    private bool readyToRegen = true;

    void Start()
    {
        heroHealth = maxHealth;
        heroMana = maxMana;
    }


    void Update()
    {
        if (readyToRegen)
        {
            StartCoroutine(Regen());
        }
    }
    public void UseItem(int mana)
    {
        heroMana -= mana;
    }


    public void TakeDamage(int damage)
    {

        getDamage = damage;
        heroHealth -= (damage);
        Debug.Log("Megütötték a hőst!");

        DamagePopup();


        if (heroHealth <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        
            //megállítja az időt és megjeleníti a gameover panelt
            Time.timeScale = 0;
            Debug.Log("A hős halott");
            gameOverPanel.SetActive(true);
        
    }

    public void DamagePopup()
    {
        //létrehozza és elmenti az új popupot, hogy átadhassa neki a damaget
        GameObject popup = Instantiate(damagePopup, damagePopupPos.position, Quaternion.identity);
        PopupDestroy popupScript = popup.GetComponent<PopupDestroy>();
        
        //átadja a kapott damaget a másik scriptnek
        popupScript.setPopupText(getDamage);

    }

    IEnumerator Regen()
    {
        readyToRegen = false;
        //Debug.Log("wut");

        if (heroHealth < 100)
        {
            heroHealth += 1 * healthRegenMultiplier;
        }

        if (heroMana < 100)
        {
            heroMana += 1 * manaRegenMultiplier;
        }

        WaitForSeconds regenTime = new WaitForSeconds(1);
        yield return regenTime;

        readyToRegen = true;
    }

}
