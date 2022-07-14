using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    public static float playerCoins;
    /// <summary>
    /// Beállítja a poweruppokat alapértékre. 
    /// </summary>
    public static bool isInited;
    /// <summary>
    /// Beállítja az egységek alap értékeit
    /// </summary>
    public static bool unitsInited;

    public static int reachedLevel = 1;

    //társak erő szorzói
    public static float swordsmanPowerup;
    public static float spearmanPowerup;
    public static float cavarlyPowerup;
    public static float armoredKnightPowerup;
    public static float magePowerup;

    //társak értékei

    /*public static float swordsmanCost;
    public static float spearmanCost;
    public static float cavarlyCost;
    public static float knightCost;
    public static float mageCost;*/



    public struct Ally
    {
        public string name;
        public float hp;
        public float attack;
        public float hitSpeed;
        public float cost;

        public bool isUnlocked;

        public Ally(string name, float hp, float attack, float hitSpeed, float cost, bool isUnlocked)
        {
            this.name = name;
            this.hp = hp;
            this.attack = attack;
            this.hitSpeed = hitSpeed;
            this.cost = cost;

            this.isUnlocked = isUnlocked;
        }

    }

    public static Ally swordsman = new Ally("Swordsman", 0, 0, 0, 10, true);
    public static Ally spearman = new Ally("Spearman", 0, 0, 0, 10, false);
    public static Ally cavarly = new Ally("Cavarly", 0, 0, 0, 10, false);
    public static Ally knight = new Ally("Knight", 0, 0, 0, 10, false);
    public static Ally mage = new Ally("Mage", 0, 0, 0, 10, false);

    public static Ally[] allyStats = new Ally[5];

        

    //ellenség erő szorzói



}

