using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TiltPuzzlePlatforms : MonoBehaviour
{
    public GameObject[] platforms;
    public float rotationSpeed = 10f;
    public float leverRotationFactor = 1f;

    private float currentLeverRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentRotation = transform.localRotation.eulerAngles.z;

        float rotationChange = currentRotation - currentLeverRotation;
        currentLeverRotation = currentRotation;

        foreach (GameObject platform in platforms)
        {
            platform.transform.Rotate(0, 0, rotationChange * rotationSpeed * leverRotationFactor);
        }
    } 
}
