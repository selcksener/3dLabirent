using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HomeBasildi : MonoBehaviour {

    int home;
    Canvas SplashCanvas;

    void Start()
    {
        SplashCanvas = GameObject.Find("SplashCanvas").GetComponent<Canvas>() ;
        home = PlayerPrefs.GetInt("homeBasildi");
        Debug.Log(home);
        if (home == 1)
        {
            SplashCanvas.enabled = false;

        }
    }

   
}
