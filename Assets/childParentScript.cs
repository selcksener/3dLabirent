using System.Collections;
using UnityEngine;

public class childParentScript : MonoBehaviour

{
    public GameObject player;
    public Transform playerTransform;
    private bool platformBool = false;

    public void Start()
    {
    }

    //Karakter hareketli platforma değdiğinde karakter platformun child'ı oluyor.Hareketli platform sabit platforma dediğinde karakter child^den çıkıyor.
    //Bu sırada karakterin kontrolleri devre dışı kalıyor.Sonra tekrar aktif oluyor.
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Karakter child oldu");
            //  playerTransform.transform.parent = this.transform;
            //playerTransform.transform.position = this.transform.position;
            //  player.GetComponent<Rigidbody>().isKinematic = true;
            //player.transform.localPosition = Vector3.zero;
            //  platformBool = true;
            // playerTransform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z / 2);

            // playerTransform.localScale = new Vector3(playerTransform.lossyScale.x, playerTransform.lossyScale.y, playerTransform.lossyScale.z);

            //other.transform.SetParent(transform, true);
            playerTransform.transform.parent = this.transform;
            // other.transform.localScale = new Vector3(other.transform.localScale.x, other.transform.localScale.x, other.transform.localScale.x);
        }

        if (other.gameObject.tag == "movingPlatform")
        {
            playerTransform.transform.parent = null;
            Debug.Log("Karakter child'dan çıktı");
            // player.GetComponent<Rigidbody>().isKinematic = false;
            Debug.Log("Değdi");
            //  platformBool = false;c
        }
    }

    /* private void Update()
     {
         if (platformBool)
         {
             playerTransform.Translate(Vector3.forward * Time.deltaTime, Space.World);
         }
     }*/
}