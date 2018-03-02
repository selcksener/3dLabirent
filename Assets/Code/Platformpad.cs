using System.Collections;
using UnityEngine;

public class Platformpad : MonoBehaviour
{
    public Transform[] path;
    public float speed = 5.0f;
    public float reachDist = 1.0f;
    public int currentPoint = 0;
    public float timer = 3.0f;

    private void Start()
    {
    }

    private void Update()
    {
        //	Vector3 dir=path[currentPoint].position - transform.position  ;
        float dist = Vector3.Distance(path[currentPoint].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position, Time.deltaTime * speed);
        if (dist <= reachDist)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                currentPoint++;
                timer = 3.0f;
            }
        }
        if (currentPoint >= path.Length)
        {
            currentPoint = 0;
        }
    }

    private void OnDrawGizmos()
    {
        if (path.Length > 0)
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] != null)
                {
                    Gizmos.DrawSphere(path[i].position, reachDist);
                }
            }
    }
}