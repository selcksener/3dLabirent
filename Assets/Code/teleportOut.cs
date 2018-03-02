using UnityEngine;
using System.Collections;

public class teleportOut : MonoBehaviour
{
    private float zaman = 0f;

    public GameObject[] newPositions;
    private float[] positionX;
    private float[] positionY;
    private float[] positionZ;
    public float timer;
    private Vector3[] position;
    public float teleportTimer;
    private float startTimer = 0f;
    private int lenght = 0;
    public GameObject teleportObject;
    private float teleportTime;

    private void Start()
    {
        teleportTime = teleportTimer;
        positionX = new float[newPositions.Length];
        positionY = new float[newPositions.Length];
        positionZ = new float[newPositions.Length];

        for (int i = 0; i < newPositions.Length; i++)
        {
            positionX[i] = newPositions[i].transform.position.x;
            positionY[i] = newPositions[i].transform.position.y;
            positionZ[i] = newPositions[i].transform.position.z;
        }
    }

    public void Update()
    {
        zaman += Time.deltaTime;
        if (zaman > timer)
        {
            zaman = 0f;
            lenght = 0;
            startTimer = 0;
            teleportTime = teleportTimer;
        }
        else
        {
            if (zaman > startTimer && zaman < teleportTime)
            {
                teleportObject.transform.position = new Vector3(positionX[lenght], positionY[lenght], positionZ[lenght]);
            }
            else if (zaman >= teleportTime)
            {
                lenght++;

                startTimer += teleportTimer;
                teleportTime += teleportTime;
            }
        }
    }
}