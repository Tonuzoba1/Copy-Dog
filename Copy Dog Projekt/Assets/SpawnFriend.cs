using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFriend : MonoBehaviour
{
    public GameObject spawnPoint;

    public GameObject swordsmanPrefab;
    public GameObject spearmanPrefab;
    public GameObject cavarlyPrefab;
    public GameObject armoredKnightPrefab;
    public GameObject wizardPrefab;


    public CharacterMovement chMv;

    void Start()
    {
        spawnPoint = GameObject.Find("Spawner");
    }


    //A gombok funkciói - külon van a sima spawn metódustól, azért, hogy elkerüljük a többszöri futtatást
    public void SwordsMan()
    {
        if (chMv.meatValue >= 5) {

            float spawnPointX = spawnPoint.transform.position.x;
            float spawnPointY = spawnPoint.transform.position.y;

            float random = Random.Range(-1f, 1f);
            Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

            //Debug.Log(newSpawnPoint);

            Instantiate(swordsmanPrefab, newSpawnPoint, Quaternion.identity);
            chMv.meatValue -= 5;
        }
    }

    public void SpearMan()
    {
        if (chMv.meatValue >= 8)
        {
            float spawnPointX = spawnPoint.transform.position.x;
            float spawnPointY = spawnPoint.transform.position.y;

            float random = Random.Range(-1f, 1f);
            Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

            Debug.Log(newSpawnPoint);

            Instantiate(spearmanPrefab, newSpawnPoint, Quaternion.identity);
            chMv.meatValue -= 8;
        }
    }

    public void Cararly()
    {
        if (chMv.meatValue >= 10)
        {
            float spawnPointX = spawnPoint.transform.position.x;
            float spawnPointY = spawnPoint.transform.position.y;

            float random = Random.Range(-1f, 1f);
            Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

            Debug.Log(newSpawnPoint);

            Instantiate(cavarlyPrefab, newSpawnPoint, Quaternion.identity);
            chMv.meatValue -= 10;
        }
    }

    public void ArmoredKnight()
    {
        if (chMv.meatValue >= 15)
        {
            float spawnPointX = spawnPoint.transform.position.x;
            float spawnPointY = spawnPoint.transform.position.y;

            float random = Random.Range(-1f, 1f);
            Vector2 newSpawnPoint = new Vector2(spawnPointX, spawnPointY + random);

            Debug.Log(newSpawnPoint);

            Instantiate(armoredKnightPrefab, newSpawnPoint, Quaternion.identity);
            chMv.meatValue -= 15;
        }
    }

    public void Wizard()
    {
        if (chMv.meatValue >= 20)
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

}
