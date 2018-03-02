using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleButonActive : MonoBehaviour
{
    private ST_PuzzleDisplay completeBool;
    private bool cBool;
    public Text puzzleCompleteTimeText;
    private AudioSource backgroundAudio;
    private AudioSource puzzleAudio;
    private AudioSource winMusic;

    public GameObject cameraObject;
    public GameObject puzzle;
    public GameObject doorDestroy;
    public GameObject ballScriptActiveButton;
    public GameObject gameOverCanvas;

    public Button puzzleButton;
    public Canvas puzzleCanvas;

    public Text puzzleTimeText;

    private Rigidbody ballObject;

    public float posX = 5f;
    public float posY = 5f;
    public float posZ = 5f;
    public float puzzleTime = 190;
    public GameObject puzzleTimeTextGameObject;
    private float speed = 1.0f;
    private float cameraRotateX;
    private float cameraRotateY;
    private float cameraRotateZ;

    private bool puzzleActiveBool = false;
    private bool time = false;

    private float puzzlePosX;
    private float puzzlePosY;
    private float puzzlePosZ;
    private float puzzleCompleteTime = 0;
    public AudioClip puzzleMusic;
    public bool changeMusic = false;
    private bool puzzleActiveMusic = false;
    private AudioSource audio;
    public GameObject controlCanvas;
    public Button puzzleActiveButton;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        ballObject = GameObject.Find("Ball").GetComponent<Rigidbody>();
        /* Bulmacanın oyun içerisindeki pozisyonunu hesaplayan işlemler */
        puzzlePosX = puzzle.transform.position.x;
        puzzlePosY = puzzle.transform.position.y;
        puzzlePosZ = puzzle.transform.position.z;
    }

    private void Update()
    {
        if (puzzleActiveBool)
        {
            puzzleTime -= Time.deltaTime;
            puzzleCompleteTime += Time.deltaTime;
            puzzleTimeText.text = "" + Mathf.RoundToInt(puzzleTime);
            puzzleCompleteTime += Time.deltaTime;
            puzzleCompleteTimeText.text = "" + Mathf.RoundToInt(puzzleCompleteTime);
            if (puzzleTime < 0)
            {
                GameObject.Find("Canvas").gameObject.SetActive(false);
                time = true;
                Control();
                puzzleTime = 0;
            }
            if (changeMusic)//Puzzle butonuna bastığında true oluyor.
            {
                if (AudioListener.volume >= 0.1f)// volume 0.01 olana kadar sesi azaltıyor.
                {
                    AudioListener.volume -= 0.008f;
                    if (AudioListener.volume <= 0.1f)// ses 0.01 olduğunda arka plan müziği duruyor.
                    {
                        audio.Stop();// Background Müzik duruyor
                        puzzleActiveMusic = true;
                    }
                }
                if (puzzleActiveMusic)// ses azaldığında 0.01 olduğundad true oluyor
                {
                    AudioListener.volume += 0.05f;// ses sürekli artıyor
                    audio.clip = puzzleMusic;// yeni arka plan müziği atanıyor.
                    audio.Play(); // yeni müzik çalıyor.
                                  //  Debug.Log("PuzzleActiveMusic");

                    if (AudioListener.volume >= 0.998f) // volume 1 olduğunda tüm ifler false oluyor.
                    {
                        changeMusic = false;
                        puzzleActiveMusic = false;
                    }
                }
            }
        }
    }

    private void Control()
    {
        if (time)
        {
            audio.Stop();
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            gameOverCanvas.SetActive(true);
        }
    }

    public void PuzzleActiveButon()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        puzzleCanvas.gameObject.SetActive(false);
        changeMusic = true;// müzik fade in-out işlemi aktif oluyor.

        /* Butona basınca kamera bulmacanın görülebileceği şekilde ayarlanıyor. */
        cameraRotateX = cameraObject.transform.rotation.x;
        cameraRotateZ = cameraObject.transform.rotation.z;
        cameraRotateY = cameraObject.transform.rotation.y;
        //  Debug.Log(cameraRotateX); Debug.Log(cameraRotateY); Debug.Log(cameraRotateZ);
        /* karakterin hareketi iptal oluyor,kapı yok oluyor ve bulmaca aktif oluyor */
        ballObject.isKinematic = true;
        puzzle.SetActive(true);
        doorDestroy.SetActive(false);

        if (PlayerPrefs.GetInt("choose") == 0)
        {
            (ballScriptActiveButton.GetComponent(typeof(puzzle)) as puzzle).enabled = false;
            (cameraObject.GetComponent(typeof(FreeCamera)) as FreeCamera).enabled = false;
        }
        else if (PlayerPrefs.GetInt("choose") == 1)
        {
            (ballScriptActiveButton.GetComponent(typeof(puzzle)) as puzzle).enabled = false;
            (cameraObject.GetComponent(typeof(OnlyCameraFollow)) as OnlyCameraFollow).enabled = false;
        }
        else if (PlayerPrefs.GetInt("choose") == 2)

        {
            (ballScriptActiveButton.GetComponent(typeof(puzzle)) as puzzle).enabled = false;
            (ballScriptActiveButton.GetComponent(typeof(sensor)) as sensor).enabled = false;
            (cameraObject.GetComponent(typeof(OnlyCameraFollow)) as OnlyCameraFollow).enabled = false;
        }

        cameraObject.transform.position = new Vector3(puzzlePosX + posX, puzzlePosY + posY, puzzlePosZ + posZ);
        //cameraObject.transform.rotation = new Quaternion(-cameraRotateX,-cameraRotateY,cameraRotateZ,0);
        cameraObject.transform.eulerAngles = new Vector3(0, 0, 0);
        puzzleButton.gameObject.SetActive(false);

        /*kapı açma butonuna basınca zaman ve ekranda yazı yazan işlemler */

        puzzleTimeTextGameObject.SetActive(true);
        puzzleActiveBool = true;
        controlCanvas.SetActive(false);
    }

    public void puzzleTimeFalse()
    {
        puzzleTimeText.gameObject.SetActive(false);
    }

    public void puzzleCanvasActive()
    {
        puzzleCanvas.gameObject.SetActive(true);
        puzzleActiveButton.gameObject.SetActive(false);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
}