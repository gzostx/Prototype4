using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraX : MonoBehaviour
{    
    [SerializeField]
    private float speed = 200;
    public GameObject player;

    // Update is called once per frame
    void LateUpdate()
    {
        float mouseXRotate = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseXRotate * speed * Time.deltaTime);

        transform.position = player.transform.position; // Move focal point with player

    }
}
