using UnityEngine;
using System.Collections;

public class SoundIncrease : MonoBehaviour {
    public GameObject ballObject;
    private float objeX=0.0f;
    private float ballX = 0.0f;
    private float distance = 0.0f;
    public AudioSource audio;
    private float audioVolume = 0.001f;
	void Start()
    {
        audio = GetComponent<AudioSource>();
        objeX = transform.position.z;
        audio.Play();
        audio.volume = 0;
        
    }
    // Update is called once per frame
	void Update () {
        ballX = ballObject.transform.position.z;
        distance=Mathf.Abs(objeX-ballX);
        Debug.Log(distance);
        if(distance<30 && distance > 20)
        {
            audio.volume =audioVolume;
        }
       else if(distance<20 && distance > 10)
        {
            
            audio.volume = audioVolume + 0.001f;
        }
       else if(distance <10 && distance > 1)
        {
           
            audio.volume = audioVolume + 0.002f;
        }
       else        {
            audio.volume = 0;

        }
    }
}
