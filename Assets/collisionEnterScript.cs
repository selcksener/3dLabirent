using System.Collections;
using UnityEngine;

public class collisionEnterScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "movingPlatform")
        {
            Debug.Log("Değdi");
        }
    }
}