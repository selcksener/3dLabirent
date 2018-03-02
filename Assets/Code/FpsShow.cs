using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FpsShow : MonoBehaviour
{
    private float deltaTime = 0.0f;
    public Text text;

    private void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        text.text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
    }
}