using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPull : MonoBehaviour{
    public float minAngle = -45f;
    public float maxAngle = 45f;
    public bool switchHit = false;
    

    void Update(){
        Quaternion localRot = transform.localRotation;
        Vector3 currentEuler = localRot.eulerAngles;

        float x = currentEuler.x;
        if (x > 180f) x -= 360f;

        float y = currentEuler.y;
        float z = currentEuler.z;

        float clampedX = Mathf.Clamp(x, minAngle, maxAngle);

        if (Mathf.Abs(x - clampedX) > 0.1f)
        {
            transform.localRotation = Quaternion.Euler(clampedX, 0f, 0f);
        }

        if ((y > 0f) || (z > 0f))
        {
            transform.localRotation = Quaternion.Euler(currentEuler.x, 0f, 0f);
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("PlayerHand")){
            switchHit = true;
            print("Pulled the lever!");
        }
    }
}
