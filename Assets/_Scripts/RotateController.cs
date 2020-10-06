using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    [Range(0,360)]
    public float speedRotation, speedTranslate;
    private float horizontalInput;


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * speedRotation * Time.deltaTime);

        
    }
}
