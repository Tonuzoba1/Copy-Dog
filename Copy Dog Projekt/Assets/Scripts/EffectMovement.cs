using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMovement : MonoBehaviour
{
    public float floatUpSpeed = 3f;
    public float floatSideSpeed;


    void Start()
    {

        StartCoroutine(countdown());
        RandomSideSpeed();
    }

    void Update()
    {
        transform.position += new Vector3(floatSideSpeed, floatUpSpeed) * Time.deltaTime;
        
        if (floatSideSpeed >= 0) {
            floatSideSpeed += 0.03f;
        } else
        {
            floatSideSpeed -= 0.03f;
        }


        
    }

    IEnumerator countdown()
    {
        WaitForSeconds wfs = new WaitForSeconds(1f);

        yield return wfs;

        Destroy(gameObject);

    }

    private void RandomSideSpeed() {
        floatSideSpeed = Random.Range(-0.5f, 0.5f);
        Debug.Log(floatSideSpeed);
    }
}
