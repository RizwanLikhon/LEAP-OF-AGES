
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;



    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position+offset;
        Vector3 smoothPosition=Vector3.Lerp(targetPosition,target.position,smoothFactor*Time.fixedDeltaTime);
        transform.position = targetPosition;    
    
    }
}
