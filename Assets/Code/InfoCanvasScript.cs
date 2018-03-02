using UnityEngine;
using System.Collections;

public class InfoCanvasScript : MonoBehaviour
{
    private int count;
    private int musicState;

    private void Start()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        AudioListener.volume = 0;
    }

    public void infoTeleportCanvas()
    {
        musicState = PlayerPrefs.GetInt("count");
        Debug.Log(musicState);
        if (musicState % 2 == 0)
        {
            AudioListener.volume = 1;
        }
        else
            AudioListener.volume = 0;
        this.gameObject.SetActive(false);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;

        //AudioListener.volume = 1;
    }
}