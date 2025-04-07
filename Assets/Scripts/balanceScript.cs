using UnityEngine;

public class BarBalancer : MonoBehaviour
{
    public Rigidbody leftMass;
    public Rigidbody rightMass;
    public float armLength = 1f;
    public float angleMultiplier = 1f; // Controls angle sensitivity to mass difference
    public float minRotationZ = -30f; // degrees
    public float maxRotationZ = 30f;

    public float smoothTime = 0.5f; // Adjust this for snappier or smoother transitions

    private float currentVelocityZ = 0f; // Required for SmoothDampAngle

    void FixedUpdate()
    {
        // Compute torques from each side
        float massLeft = leftMass.mass;
        float massRight = rightMass.mass;

        float torqueLeft = massLeft * Physics.gravity.magnitude * armLength;
        float torqueRight = massRight * Physics.gravity.magnitude * armLength;
        float netTorque = torqueLeft - torqueRight;

        // Determine target angle from net torque
        float targetAngleZ = Mathf.Clamp(netTorque * angleMultiplier, minRotationZ, maxRotationZ);

        // Get current Z rotation in degrees (-180 to 180)
        float currentZ = transform.localEulerAngles.z;
        if (currentZ > 180f) currentZ -= 360f;

        // Smoothly damp to the target
        float newZ = Mathf.SmoothDampAngle(currentZ, targetAngleZ, ref currentVelocityZ, smoothTime);

        // Apply the new rotation
        transform.localRotation = Quaternion.Euler(0f, 0f, newZ);
    }
}


