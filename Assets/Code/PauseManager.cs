using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR

using UnityEditor;

#endif

public class PauseManager : MonoBehaviour
{
    private Canvas PauseCanvas;
    private Canvas MenuCanvas;
    private int scene;
    public GameObject PauseMenuSettingButton;
    private Button pauseButton;
    public Rigidbody ballRigibdoy;

    // Use this for initialization
    private void Start()
    {
        pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
        PauseCanvas = GetComponent<Canvas>();
        scene = SceneManager.GetActiveScene().buildIndex;// Scene indeksini öğrenme komutu
                                                         // PlayerPrefs.SetInt("scene", scene);
        PauseCanvas.enabled = false;
    }

    public void Pause()
    {
        ballRigibdoy.velocity = Vector3.zero;
        pauseButton.interactable = !pauseButton.interactable;
        PauseCanvas.enabled = !PauseCanvas.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void Resume()
    {
        pauseButton.interactable = !pauseButton.interactable;
        PauseCanvas.enabled = !PauseCanvas.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void Menu()
    {
        Application.LoadLevel(0);
        //AudioListener.volume = 1;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        //Pause();
    }

    public void Restart()
    {
        Pause();

        Application.LoadLevel(Application.loadedLevel);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
		Application.Quit();

#endif
    }

    // Menü buton eventleri
    public void settingbutton()
    {
        Application.LoadLevel("SettingScene");
    }

    public void shopButton()
    {
        Application.LoadLevel("ShopScene");
    }

    public void infoScene()
    {
        Application.LoadLevel(12);
    }

    // Scene Back Button
    public void backButton()
    {
        Application.LoadLevel("menu");
    }

    public void pauseSettingButton()
    {
        PauseMenuSettingButton.SetActive(true);
    }

    public void settingPanelBackButton()
    {
        PauseMenuSettingButton.SetActive(false);
    }

    public void selectLevel()
    {
        Application.LoadLevel(11);
    }

    public void nextLevel()
    {
        Pause();
        if (scene == 10)
            Application.LoadLevel(0);
        Application.LoadLevel(scene + 1);
    }

    public void puzzleCompleteCanvasRestart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}