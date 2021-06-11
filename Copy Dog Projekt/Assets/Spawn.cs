using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject enemySpawnPoint;
    
    //társak
    public GameObject swordsmanPrefab;
    public GameObject spearmanPrefab;
    public GameObject cavarlyPrefab;
    public GameObject armoredKnightPrefab;
    public GameObject wizardPrefab;

    //ellenségek
    public GameObject enemySwordsman;
    public GameObject enemyEliteSwordsman;
    public GameObject enemyCavarly;
    public GameObject enemyHammer;
    public GameObject enemyKnight;


    public bool readyToSpawn = false;

    public CharacterMovement chMv;

    

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("Spawner");
        enemySpawnPoint = GameObject.Find("EnemySpawner");

        StartCoroutine(SpawnEnemy());
    }

     //Update is called once per frame
    void Update()
    {
        //ellenség spawnolása

        if (readyToSpawn)
        {
            StartCoroutine(SpawnEnemy());
        }


        //társak spawnolása
        if (Input.GetKeyDown("1") && chMv.meatValue >= 5)
        {
            float spawnPointX = spawnPoint.transform.position.x;
            float spawnPointY = spawnPoint.transform.position.y;

            float random = Random.Range(-1f, 1f);
            Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

            Debug.Log(newSpawnPoint);

            Instantiate(swordsmanPrefab, newSpawnPoint, Quaternion.identity);
            chMv.meatValue -= 5;

        }

        if (Input.GetKeyDown("2") && chMv.meatValue >= 8)
        {
            float spawnPointX = spawnPoint.transform.position.x;
            float spawnPointY = spawnPoint.transform.position.y;

            float random = Random.Range(-1f, 1f);
            Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

            Debug.Log(newSpawnPoint);

            Instantiate(spearmanPrefab, newSpawnPoint, Quaternion.identity);
            chMv.meatValue -= 8;

        }

        if (Input.GetKeyDown("3") && chMv.meatValue >= 10)
        {
            float spawnPointX = spawnPoint.transform.position.x;
            float spawnPointY = spawnPoint.transform.position.y;

            float random = Random.Range(-1f, 1f);
            Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

            Debug.Log(newSpawnPoint);

            Instantiate(cavarlyPrefab, newSpawnPoint, Quaternion.identity);
            chMv.meatValue -= 10;

        }

        if (Input.GetKeyDown("4") && chMv.meatValue >= 15)
        {
            float spawnPointX = spawnPoint.transform.position.x;
            float spawnPointY = spawnPoint.transform.position.y;

            float random = Random.Range(-1f, 1f);
            Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

            Debug.Log(newSpawnPoint);

            Instantiate(armoredKnightPrefab, newSpawnPoint, Quaternion.identity);
            chMv.meatValue -= 15;

        }

        if (Input.GetKeyDown("5") && chMv.meatValue >= 20)
        {
            float spawnPointX = spawnPoint.transform.position.x;
            float spawnPointY = spawnPoint.transform.position.y;

            float random = Random.Range(-1f, 1f);
            Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

            Debug.Log(newSpawnPoint);

            Instantiate(wizardPrefab, newSpawnPoint, Quaternion.identity);
            chMv.meatValue -= 20;

        }

    }

    IEnumerator SpawnEnemy()
    {
        readyToSpawn = false;

        int spawnDice = Random.Range(1, 5);
        Debug.Log(spawnDice);

        switch (spawnDice)
        {
            case 1:
                {
                    float spawnPointX = enemySpawnPoint.transform.position.x;
                    float spawnPointY = enemySpawnPoint.transform.position.y;

                    float random = Random.Range(-1f, 1f);
                    Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

                    //Debug.Log(newSpawnPoint);

                    Instantiate(enemySwordsman, newSpawnPoint, Quaternion.identity);

                    break;
                }
            case 2:
                {
                    float spawnPointX = enemySpawnPoint.transform.position.x;
                    float spawnPointY = enemySpawnPoint.transform.position.y;

                    float random = Random.Range(-1f, 1f);
                    Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

                    //Debug.Log(newSpawnPoint);

                    Instantiate(enemyEliteSwordsman, newSpawnPoint, Quaternion.identity);

                    break;
                }
            case 3:
                {
                    float spawnPointX = enemySpawnPoint.transform.position.x;
                    float spawnPointY = enemySpawnPoint.transform.position.y;

                    float random = Random.Range(-1f, 1f);
                    Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

                    //Debug.Log(newSpawnPoint);

                    Instantiate(enemyCavarly, newSpawnPoint, Quaternion.identity);

                    break;
                }
            case 4:
                {
                    float spawnPointX = enemySpawnPoint.transform.position.x;
                    float spawnPointY = enemySpawnPoint.transform.position.y;

                    float random = Random.Range(-1f, 1f);
                    Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

                    //Debug.Log(newSpawnPoint);

                    Instantiate(enemyHammer, newSpawnPoint, Quaternion.identity);

                    break;
                }
            case 5:
                {
                    float spawnPointX = enemySpawnPoint.transform.position.x;
                    float spawnPointY = enemySpawnPoint.transform.position.y;

                    float random = Random.Range(-1f, 1f);
                    Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

                    //Debug.Log(newSpawnPoint);

                    Instantiate(enemyKnight, newSpawnPoint, Quaternion.identity);

                    break;
                }


        }


        /*float spawnPointX = enemySpawnPoint.transform.position.x;
        float spawnPointY = enemySpawnPoint.transform.position.y;

        float random = Random.Range(-1f, 1f);
        Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

        Debug.Log(newSpawnPoint);

        Instantiate(enemySwordsman, newSpawnPoint, Quaternion.identity);
        */

        yield return new WaitForSeconds(5);

        readyToSpawn = true;
        
    }
}
