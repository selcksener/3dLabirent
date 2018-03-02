using UnityEngine;
using System.Collections;

public class pickUpSounds : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip puzzlePickUpSound;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audio.PlayOneShot(puzzlePickUpSound);
        }
    }
}