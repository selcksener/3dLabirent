using UnityEngine;
using System.Collections;

public class PipeRotation : MonoBehaviour
{
    public float rotationY = 1f;
    public bool isSet = false;
    void Update()
    {
        if (isSet != true)
        {
            StartCoroutine(eulerAngleY());
        }
    }
    IEnumerator eulerAngleY()
    {
        if (transform.eulerAngles.y>180 && transform.eulerAngles.y < 180.3 || transform.eulerAngles.y > 90 && transform.eulerAngles.y < 90.2 || transform.eulerAngles.y > 270 && transform.eulerAngles.y < 270.2 || transform.eulerAngles.y > 360 && transform.eulerAngles.y < 360.2)
        {
            isSet = true;
            yield return new WaitForSeconds(3);
        }
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + rotationY * Time.deltaTime,transform.eulerAngles.z);
        isSet = false;
    }
}