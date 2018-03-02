using UnityEngine;
using System.Collections;

public class OnlyCameraFollow : MonoBehaviour
{
    public Transform lookAt;

    private Vector3 offset;
    public float distanceX = 5.0f;
    public float distanceY = 5.0f;
    public float distanceZ = 5.0f;
    private float yoffset = 3.5f;

    private void Start()
    {
        offset = new Vector3(distanceZ, distanceY, -1f * distanceX);
    }

    private void Update()
    {
        transform.position = lookAt.position + offset;
        transform.LookAt(lookAt);
    }
}