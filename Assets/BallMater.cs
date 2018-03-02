using UnityEngine;
using System.Collections;

public class BallMater : MonoBehaviour
{
    public GameObject ballObject;
    private Material ballMater;
    Renderer render;
    // Use this for initialization
    void Start()
    {
        render = ballObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BomBall")
        {
            render.material = ballMater;
            ballObject.tag = "Player";
            Destroy(gameObject);
        }
    }
}