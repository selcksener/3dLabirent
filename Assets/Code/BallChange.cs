using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallChange : MonoBehaviour
{
    private GameObject ballObject;
    private GameObject bombObje;
    public Material bombMater;

    private Renderer render;
    private GameObject[] walls;
    private bool wallIsTrigger = true;

    private void Start()
    {
        bombObje = GameObject.Find("BombButton");

        ballObject = GameObject.Find("Ball");
        render = GetComponent<Renderer>();
    }

    public void ButtonActive()
    {
        walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<Collider>().isTrigger = true;
        }
        ballObject.GetComponent<Renderer>().material = bombMater;
        ballObject.tag = "BombBall";
    }

    /*
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "BombBall")
            {
                bombObje.GetComponent<Button>().interactable = false;
                // Destroy(gameObject);
                wallIsTrigger = false;
                ballObject.GetComponent<Renderer>().material = bombMater;
                ballObject.tag = "BombBall";
            }
        }*/

    private void Update()
    {
        if (wallIsTrigger == false)
        {
            foreach (GameObject wall in walls)
            {
                wall.GetComponent<Collider>().isTrigger = false;
            }

            wallIsTrigger = true;
        }
    }
}