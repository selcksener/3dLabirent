using UnityEngine;
using System.Collections;

public class FreeCamera : MonoBehaviour
{
    public VirtualJoystick cameraJoystick;

    public Transform lookAt;

    public float distanceX = 10.0f;
    public float distanceY = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivyX = 3.0f;
    private float sensitivyY = 1.0f;
    private const float yMin = -30.0f;
    private const float yMax = 40.0f;
    private float posY;

    public Transform CamTransform { get; internal set; }

    private void Update()
    {
        currentX += cameraJoystick.InputDirection.x * sensitivyX;
        currentY += cameraJoystick.InputDirection.z * sensitivyY;
        currentY = Mathf.Clamp(currentY, yMin, yMax);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, distanceY, -distanceX);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = lookAt.position + rotation * dir;
        transform.LookAt(lookAt);
    }
}