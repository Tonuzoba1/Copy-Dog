using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public Rigidbody rb;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d")){
            rb.AddForce(0, 0, 30);
        }

        Vector3 camVec = new Vector3(0,0,0);

        cam.transform.Rotate(camVec);
    }
}
