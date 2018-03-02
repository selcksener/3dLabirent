using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class puzzle : MonoBehaviour
{
    public Text timeText;
    public Text pieceText;
    public GameObject puzzleText;

    public Button puzzleButton;

    public GameObject puzzleActiveDoor;
    public GameObject ballObject;
    public GameObject gameOverCanvas;

    public AudioClip puzzlePickUp;

    private AudioSource audio;
    private AudioSource backgroundSound;
    private AudioSource gameOverSound;

    private AudioSource gameControllerAudioSource;
    public GameObject gameControllerMusic;
    public int sayac = 0;
    public float timeIncrement = 200;
    private AudioSource audioGameOver;
    private bool topladi = false;
    private float extraScore;

    private teleportOut teleportScript;

    private void Start()
    {
        gameOverCanvas.SetActive(false);
        audioGameOver = gameControllerMusic.GetComponent<AudioSource>();
        audio = GetComponent<AudioSource>();
        AudioSource[] audios = GetComponents<AudioSource>();
        backgroundSound = audios[0];
        gameOverSound = audios[1];

        puzzleButton.gameObject.SetActive(false);
        // puzzleText.gameObject.SetActive(false);
    }

    private void Update()
    {
        timeIncrement -= Time.deltaTime; ;
        if (timeIncrement < 0)
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            timeIncrement = 0;
            // Debug.Log("sıfır");
            gameOverCanvas.SetActive(true);
            audioGameOver.Stop();
        }

        UpdateText();
    }

    private void UpdateText()
    {
        timeText.text = "" + Mathf.RoundToInt(timeIncrement);
    }

    /* Top, puzzle parçalarını aldığında parçalar yok oluyor ve ses efekti aktif oluyor. */

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "kutu")
        {
            audio.PlayOneShot(puzzlePickUp);
            Destroy(other.gameObject);
            sayac++;
            UpdatePiece();
            if (sayac == 5)
            {
                topladi = true;

                puzzleText.gameObject.SetActive(true);
                yield return new WaitForSeconds(2);
                puzzleText.gameObject.SetActive(false);
            }
        }
        else if (other.tag == "gem")
        {
            UpdateText();
            Destroy(other.gameObject);
        }
        else if (other.tag == "scorebox")
        {
            timeIncrement += 15;
            UpdateText();
            (gameControllerMusic.GetComponent(typeof(teleportOut)) as teleportOut).enabled = false;
            Destroy(other.gameObject);
        }
        else if (other.tag == "teleportOut")

        {
            (this.GetComponent(typeof(Motor)) as Motor).enabled = true;
        }
        else if (other.tag == "dead")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        /*  if (topladi)
          {
              if (other.gameObject.tag == "kapi")
              {
                  puzzleButton.gameObject.SetActive(true);
              }
              else
                  puzzleButton.gameObject.SetActive(false);
          }*/
    }

    private void UpdatePiece()
    {
        pieceText.text = sayac + "/5";
    }

    private void OnTriggerStay(Collider other)

    {
        if (topladi)
        {
            if (other.gameObject.tag == "kapi")
            {
                puzzleButton.gameObject.SetActive(true);
            }
            else
                puzzleButton.gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        puzzleButton.gameObject.SetActive(false);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("choose", 0);
        PlayerPrefs.SetInt("count", 0);
    }
}