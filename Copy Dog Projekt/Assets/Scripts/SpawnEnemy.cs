using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Vector3 enemySpawnPoint;

    public GameObject enemySwordsman;
    public GameObject enemyEliteSwordsman;
    public GameObject enemyCavarly;
    public GameObject enemyHammer;
    public GameObject enemyKnight;


    private bool readyToSpawn = false;
    private int spawnIndex = 0;
    private int spawnTimeIndex = 0;

    private bool endOfLvl = false;

    [SerializeField] private int[] scriptedSpawnOrder; //=     { 1, 1, 2, 2, 1, 3, 4, 1, 5 };
    [SerializeField] private float[] scriptedTimeOrder;// =    { 3, 3, 6, 6, 5, 5, 5, 6, 2 };

    // Start is called before the first frame update
    void Start()
    {

        enemySpawnPoint = transform.position;

        //StartCoroutine(SpawnNewEnemy());
        StartCoroutine(SpawnRandomEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        /*if (readyToSpawn && !endOfLvl)
        {
            StartCoroutine(SpawnNewEnemy());
        }*/

        if (readyToSpawn && !endOfLvl)
        {
            StartCoroutine(SpawnRandomEnemy());
        }
    }

    IEnumerator SpawnRandomEnemy()
    {
        readyToSpawn = false;
        int unlockedEnemy = PlayerStats.reachedLevel+1;
        if(unlockedEnemy > 6)
        {
            unlockedEnemy = 6;
        }

        int randomIndex = Random.Range(1, unlockedEnemy);
        float randomTime = Random.Range(4, 7);

        switch (randomIndex)
        {
            case 1:
                {
                    float spawnPointX = enemySpawnPoint.x;
                    float spawnPointY = enemySpawnPoint.y;

                    float random = Random.Range(-1f, 1f);
                    Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

                    //Debug.Log(newSpawnPoint);

                    Instantiate(enemySwordsman, newSpawnPoint, Quaternion.identity);

                    break;
                }
            case 2:
                {
                    float spawnPointX = enemySpawnPoint.x;
                    float spawnPointY = enemySpawnPoint.y;

                    float random = Random.Range(-1f, 1f);
                    Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

                    //Debug.Log(newSpawnPoint);

                    Instantiate(enemyHammer, newSpawnPoint, Quaternion.identity);

                    break;
                }
            case 3:
                {
                    float spawnPointX = enemySpawnPoint.x;
                    float spawnPointY = enemySpawnPoint.y;

                    float random = Random.Range(-1f, 1f);
                    Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

                    //Debug.Log(newSpawnPoint);

                    Instantiate(enemyEliteSwordsman, newSpawnPoint, Quaternion.identity);

                    break;
                }
            case 4:
                {
                    float spawnPointX = enemySpawnPoint.x;
                    float spawnPointY = enemySpawnPoint.y;

                    float random = Random.Range(-1f, 1f);
                    Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

                    //Debug.Log(newSpawnPoint);

                    Instantiate(enemyCavarly, newSpawnPoint, Quaternion.identity);

                    break;
                }
            case 5:
                {
                    float spawnPointX = enemySpawnPoint.x;
                    float spawnPointY = enemySpawnPoint.y;

                    float random = Random.Range(-1f, 1f);
                    Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

                    //Debug.Log(newSpawnPoint);

                    Instantiate(enemyKnight, newSpawnPoint, Quaternion.identity);

                    break;
                }


        }

        yield return new WaitForSeconds(randomTime);

        readyToSpawn = true;
    }

    IEnumerator SpawnNewEnemy()
    {
        readyToSpawn = false;

        /*int spawnDice = Random.Range(1, 5);
        Debug.Log(spawnDice);
        */


        switch (scriptedSpawnOrder[spawnIndex])
        {
            case 1:
                {
                    float spawnPointX = enemySpawnPoint.x;
                    float spawnPointY = enemySpawnPoint.y;

                    float random = Random.Range(-1f, 1f);
                    Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

                    //Debug.Log(newSpawnPoint);

                    Instantiate(enemySwordsman, newSpawnPoint, Quaternion.identity);

                    break;
                }
            case 2:
                {
                    float spawnPointX = enemySpawnPoint.x;
                    float spawnPointY = enemySpawnPoint.y;

                    float random = Random.Range(-1f, 1f);
                    Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

                    //Debug.Log(newSpawnPoint);

                    Instantiate(enemyHammer, newSpawnPoint, Quaternion.identity);

                    break;
                }
            case 3:
                {
                    float spawnPointX = enemySpawnPoint.x;
                    float spawnPointY = enemySpawnPoint.y;

                    float random = Random.Range(-1f, 1f);
                    Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

                    //Debug.Log(newSpawnPoint);

                    Instantiate(enemyEliteSwordsman, newSpawnPoint, Quaternion.identity);

                    break;
                }
            case 4:
                {
                    float spawnPointX = enemySpawnPoint.x;
                    float spawnPointY = enemySpawnPoint.y;

                    float random = Random.Range(-1f, 1f);
                    Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

                    //Debug.Log(newSpawnPoint);

                    Instantiate(enemyCavarly, newSpawnPoint, Quaternion.identity);

                    break;
                }
            case 5:
                {
                    float spawnPointX = enemySpawnPoint.x;
                    float spawnPointY = enemySpawnPoint.y;

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

        //Debug.Log("Spawnoltam egy " + scriptedSpawnOrder[spawnIndex] + " ennyi idővel " + scriptedTimeOrder[spawnTimeIndex]);

        //teszteli, hogy ha tovább lépne a tömbben akkor túlindexeli azt, Length-1 mivel az index 0-tól indul így a valóságban egyel kevesebbet mutat mint a valós pozíció
        if (spawnIndex + 1 > scriptedSpawnOrder.Length - 1 || spawnTimeIndex + 1 > scriptedTimeOrder.Length - 1)
        {
            endOfLvl = true;
            Debug.Log("Vége a lvl-nek " + endOfLvl);
        }
        else if (spawnIndex + 1 <= scriptedSpawnOrder.Length || spawnTimeIndex + 1 <= scriptedTimeOrder.Length)
        {
            //Debug.Log("Növeltem de miért?");
            spawnIndex++;
            spawnTimeIndex++;

        }

        yield return new WaitForSeconds(scriptedTimeOrder[spawnTimeIndex]);

        readyToSpawn = true;






    }

}
