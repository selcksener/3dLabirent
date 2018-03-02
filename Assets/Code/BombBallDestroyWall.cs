using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BombBallDestroyWall : MonoBehaviour
{
    private GameObject[] walls;
    public GameObject ballObject;
    private GameObject bombObje;
    private GameObject bomb;
    public Material BallMater;
    private Renderer render;
    private bool wallIsTrigger = true;

    // Use this for initialization
    private void Start()
    {
        //ballObject = GameObject.Find("Ball");
        render = GetComponent<Renderer>();

        bombObje = GameObject.Find("BombButton");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BombBall")
        {
            walls = GameObject.FindGameObjectsWithTag("Wall");
            bombObje.GetComponent<Button>().interactable = false;
            ballObject.GetComponent<Renderer>().material = BallMater;
            ballObject.tag = "Player";

            Debug.Log("Duvar Yok Edildi.");
            wallIsTrigger = false;
            UpdateTag();
            Destroy(gameObject);
        }
    }

    private void UpdateTag()
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