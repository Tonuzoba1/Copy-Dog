using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFriend : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject allyPrefab;

    public void Start()
    {
        spawnPoint = GameObject.Find("Spawner");
    }



    public void Stickman()
    {
        Instantiate(allyPrefab, spawnPoint.transform.position, Quaternion.identity);
    }

}
