using UnityEngine;

public class FollowPositionWithYOffset : MonoBehaviour
{
    public Transform target;
    public float yOffset = -1f;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 followPosition = target.position;
            followPosition.y += yOffset;
            transform.position = followPosition;
        }
    }
}

