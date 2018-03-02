using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BeginTimeScript : MonoBehaviour
{
    public Button myButton;

    // Use this for initialization
    private void Start()
    {
        myButton = GetComponent<Button>();
        myButton.enabled = false;
        buttonClick();
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }

    public IEnumerator buttonClick()
    {
        yield return new WaitForSeconds(5);
        myButton.enabled = true;
    }
}