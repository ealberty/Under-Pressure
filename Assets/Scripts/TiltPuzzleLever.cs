using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltPuzzleLever : MonoBehaviour
{
    public float minAngle = -45f;
    public float maxAngle = 45f;
    

    // Update is called once per frame
    void LateUpdate()
    {
        Quaternion localRot = transform.localRotation;
        Vector3 currentEuler = localRot.eulerAngles;

        float z = currentEuler.z;
        if (z > 180f) z -= 360f;

        float x = currentEuler.x;
        float y = currentEuler.y;

        float clampedZ = Mathf.Clamp(z, minAngle, maxAngle);

        if (Mathf.Abs(z - clampedZ) > 0.1f)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, clampedZ);
        }

        if ((x > 0f) || (y > 0f))
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, currentEuler.z);
        }
    }
}
