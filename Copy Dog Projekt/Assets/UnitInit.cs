using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInit : MonoBehaviour
{
    [Header("-------------------------------Swordsman-------------------------------")]
    [SerializeField] private float swordsmanHP;
    [SerializeField] private float swordsmanAttack;
    [SerializeField] private float swordsmanHitSpeed;

    [Header("-------------------------------Spearman-------------------------------")]
    [SerializeField] private float spearmanHP;
    [SerializeField] private float spearmanAttack;
    [SerializeField] private float sparmanHitSpeed;

    [Header("-------------------------------Cavarly-------------------------------")]
    [SerializeField] private float cavarlyHP;
    [SerializeField] private float cavarlyAttack;
    [SerializeField] private float cavarlyHitSpeed;

    [Header("-------------------------------Knight-------------------------------")]
    [SerializeField] private float knightHP;
    [SerializeField] private float knightAttack;
    [SerializeField] private float knightHitSpeed;

    [Header("-------------------------------Mage-------------------------------")]
    [SerializeField] private float mageHP;
    [SerializeField] private float mageAttack;
    [SerializeField] private float mageHitSpeed;

    public void Start()
    {
        if (!PlayerStats.unitsInited)
        {
            PlayerStats.allyStats[0].hp     = swordsmanHP;
            PlayerStats.allyStats[0].attack = swordsmanAttack;
            PlayerStats.allyStats[0].hitSpeed  = swordsmanHitSpeed;

            PlayerStats.allyStats[1].hp     = spearmanHP;
            PlayerStats.allyStats[1].attack = spearmanAttack;
            PlayerStats.allyStats[1].hitSpeed = sparmanHitSpeed;

            PlayerStats.allyStats[2].hp     = cavarlyHP;
            PlayerStats.allyStats[2].attack = cavarlyAttack;
            PlayerStats.allyStats[2].hitSpeed = cavarlyHitSpeed;

            PlayerStats.allyStats[3].hp     = knightHP;
            PlayerStats.allyStats[3].attack = knightAttack;
            PlayerStats.allyStats[3].hitSpeed = knightHitSpeed;

            PlayerStats.allyStats[4].hp     = mageHP;
            PlayerStats.allyStats[4].attack = mageAttack;
            PlayerStats.allyStats[4].hitSpeed = mageHitSpeed;

            PlayerStats.unitsInited = true;
            Debug.Log("inited");
        }
    }

}
