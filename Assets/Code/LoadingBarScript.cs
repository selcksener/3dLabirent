using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LoadingBarScript : MonoBehaviour
{
    public static PauseManager pauseScript;

    private AsyncOperation ao;
    public GameObject loadingScreenBg;
    public Slider progBar;
    public Text loadingText;
    public Text hintText;

    //public Text aproGames;
    public int hintNumber;

    public bool isFakeLoadingbar = false;
    public float fakeIncrement = 0f;
    private int selectLevel;
    private int scene;

    // public Text cashText;
    public float fakeTimeing = 0f;

    private string[] hintString = {
        "Işınlanmayı kullanırken rasgele yerden çıkacağını unutma! ",
        "Ayarlar bölümünden kontrolleri değiştirebilirsin.",
        "Parçaları toplarken zamana dikkat et!",
        "Google Play'de oyuna puan vererek bize destek olabilirsin.",
        "Oyunla ilgili yorumlarını paylaşarak gelişmemize yardımcı olabilirsin.",
        "Bulmacayı çözmeye başlamadan önce bulmacanın ilk haline iyi bak!" ,
        "Oyun içindeki parçaları alarak ekstra zaman kazanabilirsin.",
        "Oyun içindeki özel özelliklleri kullanırken dikkatli ol!"
};

    private void Start()
    {
        //progBar.value = 0;
        // Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        hintNumber = Random.Range(0, 6);

        //int cash = PlayerPrefs.GetInt("Cash");
        //  cashText.text = "Cash :" + cash;
    }

    public void LoadLevel01()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;

        if (scene == 10)// Burayı düzelt bölüm sahnesinde buton tıklama olayı hatalı düzelt
        {
            string select = EventSystem.current.currentSelectedGameObject.name;

            selectLevel = 0;
            //Debug.Log(selectLevel);
        }
        if (scene == 11)
        {
            string select = EventSystem.current.currentSelectedGameObject.name;
            Debug.Log("Çalıştı");
            selectLevel = int.Parse(select);
            //   selectLevel = int.Parse(select);
            //  Debug.Log(selectLevel + 1);
        }
        else
        {
            selectLevel = scene + 1;
            // Debug.Log(selectLevel);
        }
        loadingScreenBg.SetActive(true);
        progBar.gameObject.SetActive(true);
        loadingText.gameObject.SetActive(true);
        loadingText.text = "Yükleniyor...";
        // aproGames.gameObject.SetActive(true);
        hintText.gameObject.SetActive(true);
        for (int i = 0; i < 6; i++)
        {
            if (hintNumber == i)
            {
                hintText.text = "İpucu : " + hintString[i];
            }
        }
        if (isFakeLoadingbar)
        {
            StartCoroutine(LoadLevelWithRealProgress());
        }
        else
        {
            Debug.Log(isFakeLoadingbar);
            StartCoroutine(LoadLevelWithFakeProgress());
        }
    }

    private IEnumerator LoadLevelWithRealProgress()
    {
        yield return new WaitForSeconds(1);

        ao = SceneManager.LoadSceneAsync(selectLevel);
        Debug.Log(ao);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            progBar.value = ao.progress;

            if (ao.progress == 0.9f)
            {
                progBar.value = 1f;

                ao.allowSceneActivation = true;
            }
            Debug.Log(ao.progress);
            yield return null;
        }
    }

    private IEnumerator LoadLevelWithFakeProgress()
    {
        yield return new WaitForSeconds(2);
        while (progBar.value != 1f)
        {
            progBar.value += fakeIncrement * Time.deltaTime;
            yield return new WaitForSeconds(fakeTimeing);
        }
        while (progBar.value == 1f)
        {
            SceneManager.LoadScene(1);
            yield return null;
        }
    }
}