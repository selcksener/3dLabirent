using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChooseController : MonoBehaviour
{
    public GameObject cameraScript;
    public GameObject cameraJoystick;
    public GameObject characterJoystick;
    public GameObject BallObject;

    public Button cameraController;
    public Button sensorController;
    public Button characterController;
    public Button musicButton;

    public Text musicOFFText;
    public Text musicONText;

    public Sprite musicON;
    public Sprite musicOFF;

    private int count = 0;
    private int musicOnOFf;
    public bool boolMusic;
    private int musicState;

    private void Start()
    {
        musicONText.enabled = false;
        musicOFFText.enabled = true;

        characterController.interactable = true;
        cameraController.interactable = false;
        sensorController.interactable = true;
        (cameraScript.GetComponent(typeof(OnlyCameraFollow)) as OnlyCameraFollow).enabled = false;
        (cameraScript.GetComponent(typeof(FreeCamera)) as FreeCamera).enabled = true;
        cameraJoystick.SetActive(true);
        characterJoystick.SetActive(true);
        if (boolMusic)
        {
            PlayerPrefs.SetInt("count", 0);
        }
        count = PlayerPrefs.GetInt("count");
        Debug.Log(count);
        if (count % 2 == 0)
        {
            musicONText.enabled = false;
            musicOFFText.enabled = true;
            musicButton.image.overrideSprite = musicOFF;
            // AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
        }
        else
        {
            musicONText.enabled = true;
            musicOFFText.enabled = false;
            musicButton.image.overrideSprite = musicON;

            // AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
        }

        // kamera choose kontrol save
        if (PlayerPrefs.GetInt("choose") == 0)
            selectCameraController();
        else if (PlayerPrefs.GetInt("choose") == 1)
            selectCharacterController();
        else if (PlayerPrefs.GetInt("choose") == 2)
            selectSensorController();
        else
            selectCameraController();
    }

    public void selectCameraController()
    {
        characterController.interactable = true;
        cameraController.interactable = false;
        sensorController.interactable = true;
        (cameraScript.GetComponent(typeof(OnlyCameraFollow)) as OnlyCameraFollow).enabled = false;
        (cameraScript.GetComponent(typeof(FreeCamera)) as FreeCamera).enabled = true;
        (BallObject.GetComponent(typeof(Motor)) as Motor).enabled = true;
        (BallObject.GetComponent(typeof(sensor)) as sensor).enabled = false;

        cameraJoystick.SetActive(true);
        characterJoystick.SetActive(true);
        PlayerPrefs.SetInt("choose", 0);
    }

    public void selectCharacterController()
    {
        characterController.interactable = false;
        cameraController.interactable = true;
        sensorController.interactable = true;
        (cameraScript.GetComponent(typeof(OnlyCameraFollow)) as OnlyCameraFollow).enabled = true;
        (cameraScript.GetComponent(typeof(FreeCamera)) as FreeCamera).enabled = false;
        (BallObject.GetComponent(typeof(Motor)) as Motor).enabled = true;
        (BallObject.GetComponent(typeof(sensor)) as sensor).enabled = false;

        cameraJoystick.SetActive(false);
        characterJoystick.SetActive(true);
        PlayerPrefs.SetInt("choose", 1);
    }

    public void selectSensorController()
    {
        cameraJoystick.SetActive(false);
        characterJoystick.SetActive(false);
        characterController.interactable = true;
        cameraController.interactable = true;
        sensorController.interactable = false;
        (cameraScript.GetComponent(typeof(OnlyCameraFollow)) as OnlyCameraFollow).enabled = true;
        (cameraScript.GetComponent(typeof(FreeCamera)) as FreeCamera).enabled = false;
        (BallObject.GetComponent(typeof(Motor)) as Motor).enabled = false;
        (BallObject.GetComponent(typeof(sensor)) as sensor).enabled = true;
        PlayerPrefs.SetInt("choose", 2);
    }

    public void musicOnOff()
    {
        if (count % 2 == 0)
        {
            musicONText.enabled = true;
            musicOFFText.enabled = false;
            musicButton.image.overrideSprite = musicON;
            AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
            PlayerPrefs.SetInt("music", 0);// Müzik kapalı şuan
        }
        else if (count % 2 == 1)
        {
            musicONText.enabled = false;
            musicOFFText.enabled = true;
            musicButton.image.overrideSprite = musicOFF;
            AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
            PlayerPrefs.SetInt("music", 1);// Müzik açık şuan
        }
        count++;
        Debug.Log(count);
        PlayerPrefs.SetInt("count", count);
    }
}