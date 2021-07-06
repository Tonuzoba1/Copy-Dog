using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHit : MonoBehaviour
{

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
        
    }

    // Update is called once per frame
    void Update()
    {

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
            Debug.Log("magic");
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
