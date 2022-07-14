using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A karakter spelljét idézi meg. Jelenleg az 1-es itemen és a karakteren van meghívva ezért ha mindkét helyen aktív akkor kétszer fog lőni egyszerre. 
/// </summary>
public class SpellHit : MonoBehaviour
{
    private bool spellInProgress;

    public CharacterCombat charComb;

    public ParticleSystem spellEffect;

    public Transform spellHitPoint;
    public float spellRange;

    public int spellDamage = 10;

    public Collider2D[] hitEnemies;
    public LayerMask enemyLayers;
    // Start is called before the first frame update
    void Start()
    {
        spellEffect.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j") && !spellInProgress)
        {
            spellInProgress = true;
            SpellTakesDamage();
            Debug.Log("magic");
            spellInProgress = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (spellHitPoint == null)
            return;

        Gizmos.DrawWireSphere(spellHitPoint.position, spellRange);
    }


    public void SpellTakesDamage()
    {
        
        if(charComb.heroMana >= 10)
        {
            
            spellEffect.Play();
            charComb.heroMana -= 10;

            if (!spellEffect.isPlaying)
            {

                spellEffect.Play();
            }



            hitEnemies = Physics2D.OverlapCircleAll(spellHitPoint.position, spellRange, enemyLayers);

            if (hitEnemies.Length != 0 && hitEnemies[0] != null)
            {
                foreach (Collider2D enemy in hitEnemies)
                {

                    enemy.GetComponent<EnemyCombat>().TakeDamage(spellDamage);
                    //Debug.Log("Damage " + enemy.name);

                }
            }
        }

        
    }
}
