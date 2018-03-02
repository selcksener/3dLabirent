using UnityEngine;
using System.Collections;

public class randomColorMovingPlatform : MonoBehaviour
{
    private int r, b, g;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 0f);
            gameObject.GetComponent<Renderer>().material.SetFloat("_Metallic/_Smoothness", 0.0f);
        }
    }
}