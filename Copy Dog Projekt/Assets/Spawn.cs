using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject allyPrefab;
    public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("Spawner");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Instantiate(allyPrefab, spawnPoint.transform.position, Quaternion.identity);
        }

        //spawnPoint.transform.position = new Vector2(player.transform.position.x - 8f, player.transform.position.y);
    }
}
