using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
   
   // public GameObject [] enemyToSpawn;
   // public GameObject[] powerUpToSpawn;
   public GameObject[] GameobjectsToSpawn;

    private float timeSpawnEnemy = 1f;
    private float timeSpawnPowerUp = 3.0f;
    
    private Vector3 enemyPositionTotal;
    private Vector3 powerUpPositionTotal;
    private Vector3 positionTotal;
    private bool newPowerUp;
    [SerializeField]
    private bool newWaveEnemy;
    private int totalEnemyToInstanciate=0;
    private int totalPowerUpToInstanciate = 1;
    private string typeEnemy = "Enemy";
    private string typePowerUp = "PowerUp";

    private int countTotalPowerUp;

    private int countTotalEnemy;
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(SpawnTimeEnemy());
        //StartCoroutine(SpawnTimePowerUp());
    }

    void Update()
    {
       
        countTotalPowerUp = GameObject.FindGameObjectsWithTag("PowerUp").Length;

        countTotalEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        


        if (countTotalEnemy == 0)
        {

            DeterminateGameObjectToInstanciate(typeEnemy);


        }
        
     

        
    }
    
    IEnumerator SpawnTimeEnemy()
    {
        yield return new WaitForSeconds(timeSpawnEnemy);
       //InstanciarEnemy();
       
    }
    
    

    /*
  
    void InstanciarEnemy()
    {
        
        float enemyPositionToSpawnZ = Random.Range(10, -10);
        float enemyPositionToSpawnX = Random.Range(6, -6);
        int indexEnemyToSpawn = Random.Range(0, enemyToSpawn.Length);
        enemyPositionTotal= new Vector3(enemyPositionToSpawnX,15,enemyPositionToSpawnZ);
   
        Instantiate(enemyToSpawn[indexEnemyToSpawn], enemyPositionTotal, Quaternion.identity);
        StartCoroutine(SpawnTimeEnemy());
    }

    
    void InstanciarPowerUp()
    {
        float powerUpPositionToSpawnZ = Random.Range(10, -10);
        float powerUpPositionToSpawnX = Random.Range(6, -6);
        
        int indexPowerUpToSpawn = Random.Range(0, powerUpToSpawn.Length);
        powerUpPositionTotal= new Vector3(powerUpPositionToSpawnX,0.5f,powerUpPositionToSpawnZ);
   
        Instantiate(powerUpToSpawn[indexPowerUpToSpawn], powerUpPositionTotal, Quaternion.identity);
        StartCoroutine(SpawnTimePowerUp());
    }
    */
    
    


    void DeterminateGameObjectToInstanciate(string typeGameObject)
    {
        int vecesbucle = 0;
        int indexGameObjectToSpawn = Random.Range(0, GameobjectsToSpawn.Length);
        while (GameobjectsToSpawn[indexGameObjectToSpawn].tag != typeGameObject)
        {
            
            Debug.Log("entra en while" + vecesbucle);
            indexGameObjectToSpawn = Random.Range(0, GameobjectsToSpawn.Length);
        }
        totalEnemyToInstanciate++;
       // generatePointOfInstanciating(GameobjectsToSpawn[indexGameObjectToSpawn]);
       InstanciateGameObject(GameobjectsToSpawn[indexGameObjectToSpawn],totalEnemyToInstanciate);
    
   
    }
    
    void generatePointOfInstanciating(GameObject gameObject)
    {
        if (gameObject.CompareTag("PowerUp"))
        {
            float GamePositionToSpawnZ = Random.Range(10, -10);
            float GamePositionToSpawnX = Random.Range(6, -6);

            positionTotal= new Vector3(GamePositionToSpawnX,0.5f,GamePositionToSpawnZ);
            
        }

        if (gameObject.CompareTag("Enemy"))
        {
            float GamePositionToSpawnZ = Random.Range(5, -5);
            float GamePositionToSpawnX = Random.Range(6, -6);
            positionTotal= new Vector3(GamePositionToSpawnX,5.0f,GamePositionToSpawnZ);
            //totalEnemyToInstanciate++;
            
        }
        
    }
    
    void InstanciateGameObject(GameObject gameObject,int totalObjectToInstanciate)
    {
        for (int i = 0; i < totalObjectToInstanciate; i++)
        {
            generatePointOfInstanciating(gameObject);
            Instantiate(gameObject, positionTotal, Quaternion.identity);
            StartCoroutine(SpawnTimeEnemy());

        }

        Instantiate(GameobjectsToSpawn[2], this.transform.position, Quaternion.identity);

    }
    
}
