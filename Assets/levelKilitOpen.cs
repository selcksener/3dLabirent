using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class levelKilitOpen : MonoBehaviour
{
    private int level = 0;
    private int save;

    // Use this for initialization
    public void levelOpen()
    {
        level = PlayerPrefs.GetInt("savedLevel");
        save = SceneManager.GetActiveScene().buildIndex;// Scene indeksini öğrenme komutu
        if (level < save)
        {
            PlayerPrefs.SetInt("savedLevel", save);
        }
    }
}