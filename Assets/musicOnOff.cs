using UnityEngine;
using System.Collections;

//using UnityEditor;

public class musicOnOff : MonoBehaviour
{
    public GameObject musicOn;
    public GameObject musicOff;

    public void musicOffButton()
    {
        musicOn.SetActive(false);
        musicOff.SetActive(true);
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }

    public void musicOnButton()
    {
        musicOff.SetActive(false);
        musicOn.SetActive(true);
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }

    public void settingScene()
    {
        Application.LoadLevel(13);
    }

    /*  public void Quit()
      {
  /*#if UNITY_EDITOR

          EditorApplication.isPlaying = false;
  #else
          Application.Quit();

  #endif
      }*/

    public void Quit()
    {
        Application.Quit();
    }

    public void infoScene()
    {
        Application.LoadLevel(12);
    }

    public void selectLevel()
    {
        Application.LoadLevel(11);
    }
}