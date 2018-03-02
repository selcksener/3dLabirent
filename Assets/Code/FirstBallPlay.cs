using System.Collections;
using UnityEngine;

public class FirstBallPlay : MonoBehaviour
{
    private Material firstMater;
    private int ballChoose = 0;

    public GameObject ballObject;
    private Renderer render;
    public Material[] mater;

    // Use this for initialization
    private void Start()
    {
        render = GetComponent<Renderer>();

        //ballObject.GetComponent<Renderer>().material = mater;

        ballObject = GameObject.Find("Ball");
        ballChoose = PlayerPrefs.GetInt("Ball");

        for (int i = 0; i < 10; i++)
        {
            if (ballChoose == i)
            {
                ballObject.GetComponent<Renderer>().material = mater[i];
            }
        }
    }
}