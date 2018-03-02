using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    public float posY = 1.0f;
    private bool trigger = false;
    private Rigidbody ballObject;
    private GameObject ball;
    private GameObject CompleteCanvas;

    public float zaman = 0;

    private void Start()
    {
        ballObject = GameObject.Find("Ball").GetComponent<Rigidbody>();
        CompleteCanvas = GameObject.Find("CompletePanel");
        CompleteCanvas.SetActive(false);
    }

    private void Update()
    {
        if (trigger == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + posY, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Teleport")
        {
            ballObject.isKinematic = false;
            trigger = true;
        }
        else if (other.tag == "CompleteTeleport")
        {
            ballObject.isKinematic = true;
            Debug.Log("Complete");
            CompleteCanvas.SetActive(true);
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }
    }
}