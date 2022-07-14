using System.Collections;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public float heroHealth;
    public int heroMana;
    public int healthMultiplier;
    public int manaMultiplier;
    public int healthRegenMultiplier = 1;
    public int manaRegenMultiplier = 1;
    public GameObject gameOverPanel;
    public float getDamage;
    public GameObject damagePopup;
    public Transform damagePopupPos;
    private int maxHealth = 100;
    private int maxMana = 100;
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

    public void TakeDamage(float damage)
    {
        getDamage = damage;
        heroHealth -= (damage);

        DamagePopup();

        if (heroHealth <= 0)
        {
            GameOver();
        }
    }

    public void PushBack()
    {
        transform.position = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
    }

    public void GameOver()
    {    
            //megállítja az időt és megjeleníti a gameover panelt
            Time.timeScale = 0;
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
