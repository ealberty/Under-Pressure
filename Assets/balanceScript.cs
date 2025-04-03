using UnityEngine;

public class BarBalancer : MonoBehaviour
{
    public Rigidbody leftMass;
    public Rigidbody rightMass;
    public float armLength = 1f;
    public float torqueMultiplier = 1f;

    public float minRotationZ = -30f; // degrees
    public float maxRotationZ = 30f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
    }

    void FixedUpdate()
    {
        float massLeft = leftMass.mass;
        float massRight = rightMass.mass;

        float torqueLeft = massLeft * Physics.gravity.magnitude * armLength;
        float torqueRight = massRight * Physics.gravity.magnitude * armLength;

        float netTorque = torqueLeft - torqueRight;

        // Apply torque
        rb.AddTorque(Vector3.forward * netTorque * torqueMultiplier);

        // Clamp rotation
        ClampRotation();
    }

    void ClampRotation()
    {
        Vector3 currentRotation = transform.localEulerAngles;

        // Convert to -180 to 180
        float z = currentRotation.z;
        if (z > 180f) z -= 360f;

        z = Mathf.Clamp(z, minRotationZ, maxRotationZ);
        transform.localRotation = Quaternion.Euler(0f, 0f, z);

        // Optionally: stop the Rigidbody's rotation when clamped
        rb.angularVelocity = Vector3.zero;
    }
}

