using UnityEngine;
using System.Collections;

public class sensor : MonoBehaviour
{
    // Using same speed reference in both, desktop and other devices
    public float speed = 1000;

    public GameObject player;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = player.GetComponent<Rigidbody>();
        Main();
    }

    private void Main()
    {
        // Preventing mobile devices going in to sleep mode
        //(actual problem if only accelerometer input is used)
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            // Exit condition for Desktop devices
            if (Input.GetKey("escape"))
                Application.Quit();
        }
        else
        {
            // Exit condition for mobile devices
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            // Player movement in desktop devices
            // Definition of force vector X and Y components
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            // Building of force vector
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            // Adding force to rigidbody
            rigidbody.AddForce(movement * speed * Time.deltaTime);
        }
        else
        {
            // Player movement in mobile devices
            // Building of force vector
            Vector3 movement = new Vector3(Input.acceleration.x, 0.0f, Input.acceleration.y);
            // Adding force to rigidbody
            rigidbody.AddForce(movement * speed * Time.deltaTime);
        }
    }
}