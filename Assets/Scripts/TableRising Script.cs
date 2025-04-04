using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class TableRisingScript : MonoBehaviour
{

    public GameObject pivot;
    public int onStep = 1; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = pivot.transform.localRotation.z;
        if (onStep == 1){
            if (angle > 0.25f){
                onStep += 1;
                transform.position += new UnityEngine.Vector3(0, 0.3f, 0);
            }
        }
        if (onStep == 2){
            if (angle <= -0.12f && angle >= -0.16f){
                onStep += 1;
                transform.position += new UnityEngine.Vector3(0, 0.3f, 0);
            }
        }
        if (onStep == 3){
            if (angle >= 0.12f && angle <= 0.16f){
                onStep += 1;
                transform.position += new UnityEngine.Vector3(0, 0.3f, 0);
            }
        }
        if (onStep == 4){
            if (angle >= -0.02f && angle <= 0.02f){
                onStep += 1;
                transform.position += new UnityEngine.Vector3(0, 0.3f, 0);
            }
        }
    }
}
