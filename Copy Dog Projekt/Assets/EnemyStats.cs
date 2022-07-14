using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyStats
{
    public struct Enemy
    {
        public string name;
        public float hp;
        public float attack;
        public float hitSpeed;

        public Enemy(string name, float hp, float attack, float hitSpeed)
        {
            this.name = name;
            this.hp = hp;
            this.attack = attack;
            this.hitSpeed = hitSpeed;
        }

    }

    public static Enemy swordsman = new Enemy("Swordsman", 0, 0, 0);
    public static Enemy spearman = new Enemy("Hammer", 0, 0, 0);
    public static Enemy cavarly = new Enemy("Cavarly", 0, 0, 0);
    public static Enemy knight = new Enemy("Knight", 0, 0, 0);
    public static Enemy mage = new Enemy("MasterSwordsman", 0, 0, 0);

    public static Enemy[] enemyStats = new Enemy[5];

    public static void EnemyPowerUp()
    {
        for (int i = 0; i < enemyStats.Length; i++)
        {
            enemyStats[i].hp += 1;
            enemyStats[i].attack += 0.5f;
            enemyStats[i].hitSpeed += 0.001f;

        }

    }

}
