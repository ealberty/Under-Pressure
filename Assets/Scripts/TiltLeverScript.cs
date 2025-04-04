using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltLeverScript : MonoBehaviour
{
    public float minAngle = -45f;
    public float maxAngle = 45f;

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.localEulerAngles;

        float zRotation = currentRotation.z;
        if (zRotation > 180) zRotation -= 360;

        zRotation = Mathf.Clamp(zRotation, minAngle, maxAngle);

        transform.localEulerAngles = new Vector3(0, 0, zRotation);
        
    }
}
