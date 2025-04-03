using UnityEngine;
using System.Collections.Generic;
using TMPro;


public class WeightScale : MonoBehaviour
{

    float forceToMass;
    public float combinedForce;
    public float calculatedMass;
    public int registeredRigidbodies;
    Dictionary<Rigidbody, float> impulsePerRigidBody = new Dictionary<Rigidbody, float>();
    float currentDeltaTime;
    float lastDeltaTime;

    private void Awake()
    {
        forceToMass = 1f / Physics.gravity.magnitude;
    }

    void UpdateWeight()
    {
        //calculates sum of forces on scale
        registeredRigidbodies = impulsePerRigidBody.Count;
        combinedForce = 0;
        foreach (var force in impulsePerRigidBody.Values)
        {
            combinedForce += force;
        }

        calculatedMass = (float)(combinedForce * forceToMass);//calculates mass from force and tares scale appropriately
    }

    private void FixedUpdate()
    {
        lastDeltaTime = currentDeltaTime;
        currentDeltaTime = Time.deltaTime;
        UpdateWeight();
        transform.GetComponent<Rigidbody>().mass = calculatedMass;
    }

    private void OnCollisionStay(Collision collision)

    {
        if (collision.rigidbody != null)
        {


            if (impulsePerRigidBody.ContainsKey(collision.rigidbody))
                impulsePerRigidBody[collision.rigidbody] = collision.impulse.y / lastDeltaTime;
            else
                impulsePerRigidBody.Add(collision.rigidbody, collision.impulse.y / lastDeltaTime);

            UpdateWeight();
        }
    }
    private void OnCollisionEnter(Collision collision)

    {
        if (collision.rigidbody != null)
        {
            if (impulsePerRigidBody.ContainsKey(collision.rigidbody))
                impulsePerRigidBody[collision.rigidbody] = collision.impulse.y / lastDeltaTime;
            else
                impulsePerRigidBody.Add(collision.rigidbody, collision.impulse.y / lastDeltaTime);

            UpdateWeight();
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            impulsePerRigidBody.Remove(collision.rigidbody);
            UpdateWeight();
        }
    }
}
