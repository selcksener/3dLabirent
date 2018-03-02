using System.Collections;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float drag = 0.5f;
    public float terminalRotationSpeed = 25.0f;
    public Transform camTransform;
    private Rigidbody controller;
    public VirtualJoystick moveJoystick;
    public Vector3 MoveVector { set; get; }

    private void Start()
    {
        controller = GetComponent<Rigidbody>();
        controller.maxAngularVelocity = terminalRotationSpeed;
        controller.drag = drag;

        camTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            Vector3 dir = Vector3.zero;

            dir.x = Input.GetAxis("Horizontal");
            dir.z = Input.GetAxis("Vertical");

            if (dir.magnitude > 1)
                dir.Normalize();

            if (moveJoystick.InputDirection != Vector3.zero)
            {
                dir = moveJoystick.InputDirection;
            }

            //Rotate our direction vector with camera

            Vector3 rotatedDir = camTransform.TransformDirection(dir);
            rotatedDir = new Vector3(rotatedDir.x, 0, rotatedDir.z);
            rotatedDir = rotatedDir.normalized * dir.magnitude;

            controller.AddForce(rotatedDir * moveSpeed);
        }
    }
}