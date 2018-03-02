using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class levelButton : MonoBehaviour
{
    public Canvas loadingScreenGameObject;

    public void level()

    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
        Debug.Log("Level Buton Çalıştı!");
        loadingScreenGameObject.gameObject.SetActive(true);
        //Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void Menu()
    {
        Application.LoadLevel(0);
    }
}