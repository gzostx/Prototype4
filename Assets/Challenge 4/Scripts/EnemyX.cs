using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    private GameObject imageGameOver;

    // Start is called before the first frame update
    
    void Start()
    {
        imageGameOver = GameObject.Find("Image");
        imageGameOver.GetComponent<Image>().enabled = false;
        
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");

    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
             Destroy(gameObject);

        } 
        else if (other.gameObject.name == "Player Goal")
        {

            imageGameOver.GetComponent<Image>().enabled = true;
            StartCoroutine(WaitForNewGame());

        }

    }

    IEnumerator WaitForNewGame()
    {
        yield return new WaitForSeconds(5.0f);
        imageGameOver.GetComponent<Image>().enabled = false;
        SceneManager.LoadScene("Challenge 4");
        Destroy(gameObject);

    }

}
