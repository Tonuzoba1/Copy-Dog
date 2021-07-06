using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCombat : MonoBehaviour
{
    public enemyMovement enemyMovementScript;

    //támadás
    public Transform attackPoint;
    public float attackRange = 0.3f;
    public int attackDamage = 10;

    public LayerMask allyLayers;

    public bool combatInProgress = false;
    public bool hitInProgress = false;

    public Collider2D[] hitAllies;
    //támadás vége


    //saját érték
    public int maxHealth = 100;
    private int currentHealth;
    //saját érték vége

    public int getDamage;
    public GameObject damagePopup;
    public Transform damagePopupPos;


    //hp slider
    public Slider hpSlider;
    //hp slider vége

    void Start()
    {
        enemyMovementScript = gameObject.GetComponent<enemyMovement>();
        currentHealth = maxHealth;
        hpSlider.maxValue = maxHealth;
        hpSlider.value = currentHealth;
    }

    void Update()
    {
        //ha utkozik az enemyvel és nincs folyamatban jelenleg egy ütés akkor üt
        if (enemyMovementScript.isCollidedwAlly && !hitInProgress)
        {
            Attack();
            //Debug.Log(allyMvmntScript.isCollidedwEnemy);

        }
    }


    void Attack()
    {
        //detect
        //egy tömbbe menti ami nem lokális, hogy lejjebb is el lehessen érni
        hitAllies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, allyLayers);

        if (hitAllies.Length == 0)
        {
            //ha elfogytak az enemyk akkor vége az ütésneknek is és a harcnak is
            combatInProgress = false;
            hitInProgress = false;
        }
        else
        {
            StartCoroutine(utes());

        }
        //hit


    }

    //időzíti az ütést
    IEnumerator utes()
    {
        hitInProgress = true;
        WaitForSeconds wfs = new WaitForSeconds(1f);
        
        //egy másodpercet vár az ütéssel - ezt majd ki kell szervezni változóba ha több fajta karakter lesz h változzon a cooldown
        //mindegyikre üt aki benne van a rangeben és így belekerül a tömbbe
        if(hitAllies.Length != 0 && hitAllies[0] != null) { 
        foreach (Collider2D ally in hitAllies)
        {
            combatInProgress = true;
                if(ally.tag == "Ally")
                {
                    ally.GetComponent<AllyCombat>().TakeDamage(attackDamage);
                }

                if(ally.tag == "Player")
                {
                    ally.GetComponent<CharacterCombat>().TakeDamage(attackDamage);
                }
            Debug.Log("Damage " + ally.name);
            }
      }
        yield return wfs;
        hitInProgress = false;

    }

    //megjeleníti az ütés range-t
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    //karakter halála
    public void TakeDamage(int damage)
    {
        getDamage = damage;
        currentHealth -= damage;
        hpSlider.value = currentHealth;
        DamagePopup();

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.playerCoins += attackDamage / 2;
        Debug.Log(PlayerStats.playerCoins + " érmék száma");
        Destroy(gameObject);
    }
    //karakter halála vége

    public void DamagePopup()
    {
        //létrehozza és elmenti az új popupot, hogy átadhassa neki a damaget
        GameObject popup = Instantiate(damagePopup, damagePopupPos.position, Quaternion.identity);
        PopupDestroy popupScript = popup.GetComponent<PopupDestroy>();

        //átadja a kapott damaget a másik scriptnek
        popupScript.setPopupText(getDamage);

    }

}
