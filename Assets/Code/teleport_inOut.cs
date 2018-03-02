using UnityEngine;
using System.Collections;

public class teleport_inOut : MonoBehaviour
{
    public GameObject ballObject;
    public GameObject teleportout;
    public GameObject teleportIn;

    // Use this for initialization
    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            (teleportIn.GetComponent(typeof(teleport_in)) as teleport_in).enabled = false;
            ballObject.transform.position = new Vector3(teleportout.transform.position.x, teleportout.transform.position.y + 8f, teleportout.transform.position.z);

            ballObject.GetComponent<Rigidbody>().isKinematic = false;
            (teleportIn.GetComponent(typeof(teleport_in)) as teleport_in).enabled = true;
            (ballObject.GetComponent(typeof(Motor)) as Motor).enabled = false;
        }
    }
}