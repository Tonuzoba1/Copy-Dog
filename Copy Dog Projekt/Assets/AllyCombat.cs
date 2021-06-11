using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyCombat : MonoBehaviour
{

    private AllyMovement allyMvmntScript;

    //támadás
    public Transform attackPoint;
    public float attackRange = 0.3f;
    public int attackDamage = 10;

    public LayerMask enemyLayers;

    public bool combatInProgress = false;
    public bool hitInProgress = false;

    public Collider2D[] hitEnemies;
    //támadás vége

    //saját értékek
    public int MaxHealth = 50;
    public int currentHealth;

    //saját értékek vége
    

    private void Start()
    {
        allyMvmntScript = gameObject.GetComponent<AllyMovement>();
        currentHealth = MaxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        //ha utkozik az enemyvel és nincs folyamatban jelenleg egy ütés akkor üt
        if (allyMvmntScript.isCollidedwEnemy && !hitInProgress)
        {
            Attack();
            //Debug.Log(allyMvmntScript.isCollidedwEnemy);

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
        WaitForSeconds wfs = new WaitForSeconds(1f);
        yield return wfs;
        //egy másodpercet vár az ütéssel - ezt majd ki kell szervezni változóba ha több fajta karakter lesz h változzon a cooldown
        //mindegyikre üt aki benne van a rangeben és így belekerül a tömbbe
        if (hitEnemies.Length != 0 && hitEnemies[0] != null) { 
        foreach (Collider2D enemy in hitEnemies)
        {
            combatInProgress = true;
            enemy.GetComponent<EnemyCombat>().TakeDamage(attackDamage);
            //Debug.Log("Damage " + enemy.name);
            
        }
     }
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
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    //karakter halála vége
}
