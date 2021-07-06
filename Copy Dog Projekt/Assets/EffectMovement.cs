using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMovement : MonoBehaviour
{
    public float floatUpSpeed = 3f;


    void Start()
    {
        StartCoroutine(countdown());

    }

    void Update()
    {
        transform.position += new Vector3(0, floatUpSpeed) * Time.deltaTime;
    }

    IEnumerator countdown()
    {
        WaitForSeconds wfs = new WaitForSeconds(1f);

        yield return wfs;

        Destroy(gameObject);

    }
}
