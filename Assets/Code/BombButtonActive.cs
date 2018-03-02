using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BombButtonActive : MonoBehaviour
{
    public Button bombButton;
    private GameObject bomb;
    private float posX, posY, posZ;
    public GameObject bombBall;
    private bool destroy = false;
    public float timer = 10f;

    // Use this for initialization
    private void Start()
    {
        bombButton.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BombBall")
        {
            posX = other.transform.position.x;
            posY = other.transform.position.y;
            posZ = other.transform.position.z;
            bombButton.interactable = true;
            Destroy(other.gameObject);
            destroy = true;
        }
    }

    private void Update()
    {
        if (destroy == true)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                destroy = false;
                Instantiate(bombBall, new Vector3(posX, posY, posZ), Quaternion.identity);
                timer = 10;
            }
        }
    }
}