using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0,360)]
    public float  speedTranslate;
    private float verticalInput;
    private Rigidbody _rigidbody;
    public GameObject focusPoint;
    private PowerUp _powerUp;
    [SerializeField]
    private float repulsionForce;
    

    private void Start()
    {
        speedTranslate = 5.0f;
        _rigidbody = GetComponent<Rigidbody>();
        _powerUp = GetComponent<PowerUp>();

    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
       // transform.Translate(Vector3.forward * verticalInput * speedTranslate * Time.deltaTime);
       _rigidbody.AddForce(focusPoint.transform.forward * verticalInput * speedTranslate);
       //_rigidbody.AddForce(Vector3.forward*verticalInput*speedTranslate);
       
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && _powerUp.catchPowerUp)
        {
            Debug.Log("He entrado en repulsion");
            Vector3  repulsionDirection = other.transform.position - this.transform.position;
            other.rigidbody.AddForce(repulsionDirection * repulsionForce, ForceMode.Impulse);
        }
    }
}

