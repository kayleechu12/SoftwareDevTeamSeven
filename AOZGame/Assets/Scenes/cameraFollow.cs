using System.Collections.Specialized;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform playerTarget;

    public float cameraSmoothSpeed = 0.25f;

    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 fixedPosition = playerTarget.position + offset;
        
    }
}
