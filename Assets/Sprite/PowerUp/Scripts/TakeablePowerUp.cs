﻿using UnityEngine;
using System.Collections;

public class TakeablePowerUp : MonoBehaviour
{
    private CustomizablePowerUp customPowerUp;

    private void Start()
    {
        customPowerUp = (CustomizablePowerUp)transform.parent.gameObject.GetComponent<CustomizablePowerUp>();
        //this.audio.clip = customPowerUp.pickUpSound;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            PowerUpManager.Instance.Add(customPowerUp);
            if (customPowerUp.pickUpSound != null)
            {
                AudioSource.PlayClipAtPoint(customPowerUp.pickUpSound, transform.position);
            }
            Destroy(transform.parent.gameObject);
        }
    }
}