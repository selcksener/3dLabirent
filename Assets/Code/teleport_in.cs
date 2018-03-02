using UnityEngine;
using System.Collections;

public class teleport_in : MonoBehaviour
{
    public GameObject ballObject;
    public GameObject teleportIn;
    private bool trigger;
    private float posY = 0.1f;

    private void Update()
    {
        if (trigger == true)
        {
            if (ballObject.transform.position.y > 0)
            {
                ballObject.transform.position = new Vector3(ballObject.transform.position.x, 0, ballObject.transform.position.z);
                trigger = false;
            }
            else
            {
                ballObject.transform.position = new Vector3(ballObject.transform.position.x, ballObject.transform.position.y + posY, ballObject.transform.position.z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            trigger = true;

            ballObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}