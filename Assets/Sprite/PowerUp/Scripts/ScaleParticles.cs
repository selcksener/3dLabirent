using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ScaleParticles : MonoBehaviour
{
    private void Update()
    {
        GetComponent<ParticleSystem>().startSize = transform.lossyScale.magnitude;
    }
}