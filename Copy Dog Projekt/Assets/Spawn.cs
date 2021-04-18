using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject allyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            Instantiate(allyPrefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
