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


    /*private bool readyToSpawn = false;
    private int spawnIndex = 0;
    private int spawnTimeIndex = 0;

    private bool endOfLvl = false;
    */

    /*public int[] scriptedSpawnOrder =   { 1, 1, 2, 2, 1, 3 };
    public int[] scriptedTimeOrder =    { 1, 2, 6, 6, 5, 5 };
    */

    public CharacterMovement chMv;

    

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("Spawner");
        enemySpawnPoint = GameObject.Find("EnemySpawner");

       // StartCoroutine(SpawnEnemy());
    }

     //Update is called once per frame
    void Update()
    {
        //ellenség spawnolása

       /* if (readyToSpawn && !endOfLvl)
        {
            StartCoroutine(SpawnEnemy());
        }*/


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

    /*IEnumerator SpawnEnemy()
    {
        readyToSpawn = false;

        //int spawnDice = Random.Range(1, 5);
        //Debug.Log(spawnDice);
           


        switch (scriptedSpawnOrder[spawnIndex])
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
        




        //float spawnPointX = enemySpawnPoint.transform.position.x;
        //float spawnPointY = enemySpawnPoint.transform.position.y;

        //float random = Random.Range(-1f, 1f);
        //Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

        //Debug.Log(newSpawnPoint);

        //Instantiate(enemySwordsman, newSpawnPoint, Quaternion.identity);
        

        Debug.Log("Spawnoltam egy " + scriptedSpawnOrder[spawnIndex] + " ennyi idővel " + scriptedTimeOrder[spawnTimeIndex]);

        //teszteli, hogy ha tovább lépne a tömbben akkor túlindexeli azt, Length-1 mivel az index 0-tól indul így a valóságban egyel kevesebbet mutat mint a valós pozíció
        if (spawnIndex + 1 > scriptedSpawnOrder.Length-1 || spawnTimeIndex + 1 > scriptedTimeOrder.Length-1)
        {
            endOfLvl = true;
            Debug.Log("Vége a lvl-nek " + endOfLvl);
        }
        else if(spawnIndex + 1 <= scriptedSpawnOrder.Length || spawnTimeIndex + 1 <= scriptedTimeOrder.Length)
        {
            Debug.Log("Növeltem de miért?");
            spawnIndex++;
            spawnTimeIndex++;

        }

        yield return new WaitForSeconds(scriptedTimeOrder[spawnTimeIndex]);

        readyToSpawn = true;






    }*/


}
