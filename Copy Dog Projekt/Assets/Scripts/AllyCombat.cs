using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllyCombat : MonoBehaviour
{

    private AllyMovement allyMvmntScript;
    public Animator animator;

    //támadás
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.3f;
    [SerializeField] private float attackDamage = 10;

    [SerializeField] private LayerMask enemyLayers;

                     public bool combatInProgress = false;
    [SerializeField] private bool hitInProgress = false;
    [SerializeField] private bool isSworsdsman = false;
    [SerializeField] private bool isSpearman = false;
    [SerializeField] private bool isCavarly = false;
    [SerializeField] private bool isKnight = false;
    [SerializeField] private bool isMage = false;

    /// <summary>
    /// Az éppen az érzékelési körében található karakterek tömbbje
    /// </summary>
    public Collider2D[] hitEnemies;
    //támadás vége

    //saját értékek
    public float MaxHealth;
    public float currentHealth;

    [SerializeField] private float hitSpeed;
    //saját értékek vége

    //damage popup
    public float getDamage;
    public GameObject damagePopup;
    public Transform damagePopupPos;
    //damage popup vége

    //hp slider
    public Slider hpSlider;
    [SerializeField] GameObject hpSliderObject;
    //hp slider vége

    [SerializeField] private ParticleSystem mageHitEffect;
    [SerializeField] private GameObject mageHitEffectGO;


    private void Start()
    {
        allyMvmntScript = gameObject.GetComponent<AllyMovement>();

        AllyStatUpdater();

        currentHealth = MaxHealth;
        hpSlider.maxValue = MaxHealth;
        hpSlider.value = currentHealth;

        mageHitEffect.Stop();
        Debug.Log(MaxHealth + " " + attackDamage + " " + hitSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        //ha utkozik az enemyvel és nincs folyamatban jelenleg egy ütés akkor üt
        if (allyMvmntScript.isCollidedwEnemy && !hitInProgress)
        {
            Attack();
        }

        if(!combatInProgress && !hitInProgress)
        {
            allyMvmntScript.MoveForward();
        } 
    }

    /// <summary>
    /// Frissíti a player statban az új értékét a társ karaktereknek
    /// </summary>
    public void AllyStatUpdater()
    {
        //frissíti a statban az új értékét a karaktereknek

        if (isSworsdsman)
        {
            MaxHealth = PlayerStats.allyStats[0].hp;
            attackDamage = PlayerStats.allyStats[0].attack;
            hitSpeed = PlayerStats.allyStats[0].hitSpeed;

            PlayerStats.allyStats[0].hp = MaxHealth;
            PlayerStats.allyStats[0].attack = attackDamage;
            PlayerStats.allyStats[0].hitSpeed = hitSpeed;

            }
        else if (isSpearman)
        {
            MaxHealth = PlayerStats.allyStats[1].hp;
            attackDamage = PlayerStats.allyStats[1].attack;
            hitSpeed = PlayerStats.allyStats[1].hitSpeed;

            PlayerStats.allyStats[1].hp = MaxHealth;
            PlayerStats.allyStats[1].attack = attackDamage;
            PlayerStats.allyStats[1].hitSpeed = hitSpeed;

        }
        else if (isCavarly)
        {
            MaxHealth = PlayerStats.allyStats[2].hp;
            attackDamage = PlayerStats.allyStats[2].attack;
            hitSpeed = PlayerStats.allyStats[2].hitSpeed;

            PlayerStats.allyStats[2].hp = MaxHealth;
            PlayerStats.allyStats[2].attack = attackDamage;
            PlayerStats.allyStats[2].hitSpeed = hitSpeed;

        }
        else if (isKnight)
        {
            MaxHealth = PlayerStats.allyStats[3].hp;
            attackDamage = PlayerStats.allyStats[3].attack;
            hitSpeed = PlayerStats.allyStats[3].hitSpeed;

            PlayerStats.allyStats[3].hp = MaxHealth;
            PlayerStats.allyStats[3].attack = attackDamage;
            PlayerStats.allyStats[3].hitSpeed = hitSpeed;

        }
        else if (isMage)
        {
            MaxHealth = PlayerStats.allyStats[4].hp;
            attackDamage = PlayerStats.allyStats[4].attack;
            hitSpeed = PlayerStats.allyStats[4].hitSpeed;

            PlayerStats.allyStats[4].hp = MaxHealth;
            PlayerStats.allyStats[4].attack = attackDamage;
            PlayerStats.allyStats[4].hitSpeed = hitSpeed;

        }
    }
    void Attack()
    {
        //detect
        //egy tömbbe menti ami nem lokális, hogy lejjebb is el lehessen érni
        hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        if (hitEnemies.Length == 0)
        {
            //ha elfogytak az enemyk akkor vége az ütésneknek is és a harcnak is
            combatInProgress = false;
            hitInProgress = false;


        } else
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
        
        if (hitEnemies.Length != 0 && hitEnemies[0] != null) 
        {   
            if(isSpearman)
            {
                if(hitEnemies[0].GetComponent<FortBehav>() != null)
                {
                    hitEnemies[0].GetComponent<FortBehav>().TakeDamage(attackDamage);

                } else if(hitEnemies[0].GetComponent<EnemyCombat>() != null)
                {
                    hitEnemies[0].GetComponent<EnemyCombat>().PushBack();
                    hitEnemies[0].GetComponent<EnemyCombat>().TakeDamage(attackDamage);
                }
            
            } else if (isMage)
            {
                if (hitEnemies[0].GetComponent<FortBehav>() != null)
                {
                    hitEnemies[0].GetComponent<FortBehav>().TakeDamage(attackDamage);
                    if (mageHitEffect.isPlaying)
                    {
                        mageHitEffect.Stop();
                    }

                    if (!mageHitEffect.isPlaying)
                    {
                        mageHitEffect.Play();
                    }

                } else if(hitEnemies[0].GetComponent<EnemyCombat>() != null)
                {
                    foreach (Collider2D enemy in hitEnemies)
                    {
                        combatInProgress = true;
                        enemy.GetComponent<EnemyCombat>().TakeDamage(attackDamage);

                    }
                    if (mageHitEffect.isPlaying)
                    {
                        mageHitEffect.Stop();
                    }

                    if (!mageHitEffect.isPlaying)
                    {
                        mageHitEffect.Play();
                    }
                }
            } else if(isSworsdsman || isCavarly || isKnight)
            {
                if(hitEnemies[0].GetComponent<FortBehav>() != null)
                {
                    hitEnemies[0].GetComponent<FortBehav>().TakeDamage(attackDamage);

                } else if(hitEnemies[0].GetComponent<EnemyCombat>() != null)
                {
                    hitEnemies[0].GetComponent<EnemyCombat>().TakeDamage(attackDamage);
                }
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
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void PushBack()
    {
        transform.position = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(-500, 0), ForceMode2D.Impulse);
    }

    void Die()
    {
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
