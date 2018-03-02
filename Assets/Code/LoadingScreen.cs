using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public float number;
    public Text numberText;
    private Canvas splashCanvas;
    public int increment = 5;
    public GameObject bar, loadingPanel;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (number < 100)
        {
            number += Time.deltaTime * increment;
            numberText.text = "" + (int)number + " %";
        }
        if (number >= 100)
        {
            number = 100;
            loadingPanel.SetActive(false);
        }
        bar.transform.localScale = new Vector3(number / 100, 1, 1);
    }

    private void OnDisable()
    {
        splashCanvas = GameObject.Find("Splashcanvas").GetComponent<Canvas>();
        splashCanvas.enabled = false;
    }
}