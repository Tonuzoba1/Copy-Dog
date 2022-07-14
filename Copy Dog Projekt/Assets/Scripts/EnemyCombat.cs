using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCombat : MonoBehaviour
{
    public enemyMovement enemyMovementScript;
    //támadás
    public Transform attackPoint;
    public float attackRange = 0.3f;
    public float attackDamage = 10f;
    public LayerMask allyLayers;
    public bool combatInProgress = false;
    [SerializeField] private bool hitInProgress = false;
    [SerializeField] private bool isSworsdsman = false;
    [SerializeField] private bool isHammer = false;
    [SerializeField] private bool isCavarly = false;
    [SerializeField] private bool isKnight = false;
    [SerializeField] private bool isMasterSwordsman = false;

    /// <summary>
    /// Az éppen az érzékelési körében található karakterek tömbbje
    /// </summary>
    public Collider2D[] hitAllies;
    //támadás vége


    //saját érték
    public float maxHealth = 100;
    private float currentHealth;

    [SerializeField] private float hitSpeed;
    //saját érték vége

    public float getDamage;
    public GameObject damagePopup;
    public Transform damagePopupPos;


    //hp slider
    public Slider hpSlider;
    [SerializeField] private GameObject hpSliderObject;
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

        }
    }

    /// <summary>
    /// Frissíti a player statban az új értékét a társ karaktereknek
    /// Oda vissza frissít. Előbb lehúzza a statból az aktuálisat majd visszamenti
    /// </summary>
    public void AllyStatUpdater()
    {
        //frissíti a statban az új értékét a karaktereknek
        if (isSworsdsman)
        {
            maxHealth = EnemyStats.enemyStats[0].hp;
            attackDamage = EnemyStats.enemyStats[0].attack;
            hitSpeed = EnemyStats.enemyStats[0].hitSpeed;

            EnemyStats.enemyStats[0].hp = maxHealth;
            EnemyStats.enemyStats[0].attack = attackDamage;
            EnemyStats.enemyStats[0].hitSpeed = hitSpeed;

        }
        else if (isHammer)
        {
            maxHealth = EnemyStats.enemyStats[1].hp;
            attackDamage = EnemyStats.enemyStats[1].attack;
            hitSpeed = EnemyStats.enemyStats[1].hitSpeed;

            EnemyStats.enemyStats[1].hp = maxHealth;
            EnemyStats.enemyStats[1].attack = attackDamage;
            EnemyStats.enemyStats[1].hitSpeed = hitSpeed;
        }
        else if (isCavarly)
        {
            maxHealth = EnemyStats.enemyStats[2].hp;
            attackDamage = EnemyStats.enemyStats[2].attack;
            hitSpeed = EnemyStats.enemyStats[2].hitSpeed;

            EnemyStats.enemyStats[2].hp = maxHealth;
            EnemyStats.enemyStats[2].attack = attackDamage;
            EnemyStats.enemyStats[2].hitSpeed = hitSpeed;
        }
        else if (isKnight)
        {
            maxHealth = EnemyStats.enemyStats[3].hp;
            attackDamage = EnemyStats.enemyStats[3].attack;
            hitSpeed = EnemyStats.enemyStats[3].hitSpeed;

            EnemyStats.enemyStats[3].hp = maxHealth;
            EnemyStats.enemyStats[3].attack = attackDamage;
            EnemyStats.enemyStats[3].hitSpeed = hitSpeed;
        }
        else if (isMasterSwordsman)
        {
            maxHealth = EnemyStats.enemyStats[4].hp;
            attackDamage = EnemyStats.enemyStats[4].attack;
            hitSpeed = EnemyStats.enemyStats[4].hitSpeed;

            EnemyStats.enemyStats[4].hp = maxHealth;
            EnemyStats.enemyStats[4].attack = attackDamage;
            EnemyStats.enemyStats[4].hitSpeed = hitSpeed;
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
        WaitForSeconds wfs = new WaitForSeconds(hitSpeed);
        
        //egy másodpercet vár az ütéssel - ezt majd ki kell szervezni változóba ha több fajta karakter lesz h változzon a cooldown
        //mindegyikre üt aki benne van a rangeben és így belekerül a tömbbe
        if(hitAllies.Length != 0 && hitAllies[0] != null) {           

                if (hitAllies[0].tag == "Ally" && isHammer)
                {
                    hitAllies[0].GetComponent<AllyCombat>().PushBack();
                    hitAllies[0].GetComponent<AllyCombat>().TakeDamage(attackDamage);
                }

               else if (hitAllies[0].tag == "Player" && isHammer)
                {

                    hitAllies[0].GetComponent<CharacterCombat>().PushBack();
                    hitAllies[0].GetComponent<CharacterCombat>().TakeDamage(attackDamage);
                }

           else if (hitAllies[0].tag == "Ally" && !isHammer)
            {

                hitAllies[0].GetComponent<AllyCombat>().TakeDamage(attackDamage);
            }

           else if (hitAllies[0].tag == "Player" && !isHammer)
            {
                hitAllies[0].GetComponent<CharacterCombat>().TakeDamage(attackDamage);
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
        //Gizmos.DrawCube(attackPoint.position, new Vector3(attackRange, attackRange, attackRange));
    }
    
    public void TakeDamage(float damage)
    {
        if (!hpSliderObject.activeSelf)
        {
            hpSliderObject.SetActive(true);
        }

        getDamage = damage;
        currentHealth -= damage;
        hpSlider.value = currentHealth;
        DamagePopup();

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void PushBack()
    {
        transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
    }

    //karakter halála
    void Die()
    {
        PlayerStats.playerCoins += attackDamage / 4;
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