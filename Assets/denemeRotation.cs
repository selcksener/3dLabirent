using UnityEngine;
using System.Collections;

public class denemeRotation : MonoBehaviour
{
    public GameObject wall;
    public float aci = 0;
    public int n_aci = 0;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        aci += Time.deltaTime;
        n_aci = Mathf.RoundToInt(aci);
        wall.transform.eulerAngles = new Vector3(n_aci, 0, 0);
    }
}