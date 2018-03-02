using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelKilit : MonoBehaviour
{
    public int level = 0;
    public Button[] buttons;
    public int savedLevelReset = 0;
    public bool reset = false;

    //public Sprite levelUnlock;
    //public Sprite levelLock;
    public int levelMiktari;

    private void Start()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        // PlayerPrefs.GetInt("adsasdasd");
        /* Debug.Log(PlayerPrefs.GetInt("adsasdasd"));
         if (PlayerPrefs.GetInt("savedLevel") == 0)
         {
             PlayerPrefs.SetInt("savedLevel", 0);
         }*/
        //PlayerPrefs.SetInt("savedLevel", savedLevelReset);
        if (reset)
        {
            PlayerPrefs.SetInt("savedLevel", 0);
        }
        level = PlayerPrefs.GetInt("savedLevel");
        leveller();
    }

    private void leveller()
    {
        for (int i = 0; i < levelMiktari; i++)
        {
            if (i <= level)
            {
                //buttons[i].image.overrideSprite = levelUnlock;
                buttons[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
                buttons[i].interactable = true;
                //   Debug.Log(i + " if");
            }
            else
            {
                //buttons[i].image.overrideSprite = levelLock;
                buttons[i].GetComponentInChildren<Text>().text = (i + 1).ToString(); ;
                buttons[i].interactable = false;
                // Debug.Log(i + " else");
            }
        }
    }
}