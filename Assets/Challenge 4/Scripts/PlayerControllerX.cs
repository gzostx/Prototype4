using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private ParticleSystem fximpulse;
    private bool newFxImpuse = true;
    private float speedImpulse = 10;
    private float speed = 600;
    private GameObject focalPoint;
    public GameObject[] countDownPowerUp;
    public GameObject powerUpPoint;
    
    public bool hasPowerup;
   // public GameObject powerupIndicator;
    public int powerUpDuration = 20;

    private float normalStrength = 15; // how hard to hit enemy without powerup
    private float powerupStrength = 30; // how hard to hit enemy with powerup
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        fximpulse = GameObject.Find("FX_Mist").GetComponent<ParticleSystem>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        float horizonInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && newFxImpuse)
        {
            fximpulse.Play();
            playerRb.AddForce( speedImpulse * focalPoint.transform.forward,ForceMode.Impulse);
            newFxImpuse = false;
            StartCoroutine(NewFXImpulse());
        }
        //playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);
        playerRb.AddForce(Time.deltaTime * verticalInput * speed * focalPoint.transform.forward );
        playerRb.AddForce(Time.deltaTime * horizonInput * speed * Vector3.right);
        

        // Set powerup indicator position to beneath player
        // powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
        //countDownPowerUp[0].transform.position = transform.position + new Vector3(0, -0.6f, 0);
        powerUpPoint.transform.position = this.transform.position;
        
        

    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {

            Destroy(other.gameObject);
            hasPowerup = true;
           //powerupIndicator.SetActive(true);
           StartCoroutine(PowerupCooldown());
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        
        foreach (GameObject index in countDownPowerUp)
        {
            index.SetActive(true);
            
            yield return new WaitForSeconds(powerUpDuration/countDownPowerUp.Length);
            index.SetActive(false);
            
        }
        
        hasPowerup = false;
       // powerupIndicator.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer =  other.gameObject.transform.position - transform.position; 
           
            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }
            
        }
    }

   /// <summary>
   /// corutina que contrala el tiempo para volver a usar el impulso de velocidad.
   /// </summary>
   /// <returns></returns>
    IEnumerator NewFXImpulse()
    {
        yield return new WaitForSeconds(5);
        newFxImpuse = true;
    }



}
