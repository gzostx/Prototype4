using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speedEnemy;
    
    private  GameObject target;
    private Rigidbody _rigidbody;
    [SerializeField]
    private float forceEnemy;
    private void Start()
    {
      _rigidbody = GetComponent<Rigidbody>();
      target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 direction = (target.transform.position - this.transform.position).normalized;
         
         _rigidbody.AddForce(direction * forceEnemy,ForceMode.Force );

         if (this.transform.position.y < -15f)
         {
             Destroy(this.gameObject);
         }
      
    
    }
}
