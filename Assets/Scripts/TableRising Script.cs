using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Tripolygon.UModelerX.Runtime.MessagePack.Resolvers;
using UnityEngine;

public class TableRisingScript : MonoBehaviour
{

    private AudioSource audioSource;
    public GameObject pivot;
    public int onStep = 1;
    private int frame = 0; 
    public GameObject water;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("CheckPosition", 0f, 1f);
    }

    // Update is called once per frame
    void CheckPosition()
    {
        //if (frame == 200){
            float angle = pivot.transform.localRotation.z;
            if (onStep == 1){
                if (angle > 0.25f){
                    onStep += 1;
                    transform.position += new UnityEngine.Vector3(0, 0.3f, 0);
                    audioSource.Play();
                    StartCoroutine(Flood());
                }
            }
            if (onStep == 2){
                if (angle <= -0.12f && angle >= -0.16f){
                    onStep += 1;
                    transform.position += new UnityEngine.Vector3(0, 0.3f, 0);
                    audioSource.Play();
                }
            }
            if (onStep == 3){
                if (angle >= 0.12f && angle <= 0.16f){
                    onStep += 1;
                    transform.position += new UnityEngine.Vector3(0, 0.3f, 0);
                    audioSource.Play();
                }
            }
            if (onStep == 4){
                if (angle >= -0.02f && angle <= 0.02f){
                    onStep += 1;
                    transform.position += new UnityEngine.Vector3(0, 0.3f, 0);
                    audioSource.Play();
                }
            }
            //frame = 0;
        //}
        //frame += 1;
    }

    private IEnumerator Flood()
    {
        // Store the initial position of the object
        UnityEngine.Vector3 startPosition = water.transform.position;
        UnityEngine.Vector3 targetPosition = new UnityEngine.Vector3(startPosition.x, startPosition.y + 8f, startPosition.z);

        // Continue to rise the object until it reaches the target height
        while (water.transform.position.y < targetPosition.y)
        {
            water.transform.position += new UnityEngine.Vector3(0, 0.001f * Time.deltaTime, 0);
            yield return null;  // Wait for the next frame
        }

        // Ensure the object stops exactly at the target position
        water.transform.position = targetPosition;
    }
}
