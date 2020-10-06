using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool catchPowerUp;
    public GameObject[] timeIndicate;
    private float waitTime = 15.0f;

    private void Update()
    {
        foreach (GameObject indicate in timeIndicate)
        {
            indicate.transform.position = this.transform.position + 0.5f * Vector3.down;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            catchPowerUp = true;
            Destroy(other.gameObject);

            StartCoroutine(LifeTimePowerUP());
        }
    }

    IEnumerator LifeTimePowerUP()
    {
        foreach (GameObject index in timeIndicate)
        {
            index.SetActive(true);
            yield return new WaitForSeconds(waitTime/timeIndicate.Length);
            index.SetActive(false);
        }

        catchPowerUp = false;
    }
    
}
