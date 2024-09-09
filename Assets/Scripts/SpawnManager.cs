using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour // Este script va a ser para los Power Ups. Cambiar nombres y ajustar funcionalidad.
{

    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float timeToSpawn;

    private float totalTime;
    private GameObject obstacle;

    private void Start()
    {
        SetRandomTimeToSpawn();
        totalTime = 0;
    }
    void Update()
    {
        totalTime += Time.deltaTime;
        if (totalTime > timeToSpawn)
        {
            SpawnObstacle();
            totalTime = 0;
            SetRandomTimeToSpawn();
        }
    }

    private void SpawnObstacle()
    {
        Vector2 randomPosition = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)); //Creo un vector random (x,y).

        GameObject obstacle = Instantiate(obstaclePrefab, randomPosition, Quaternion.identity); //Lo paso como la posicion del nuevo obstáculo.

        float destroyTime = Random.Range(3f, 7f); //Calculo entre 3 y 7 s el tiempo para que se destruya.

        Destroy(obstacle, destroyTime); //Se destruye el objeto

    }

    private void SetRandomTimeToSpawn()
    {
        timeToSpawn = Random.Range(3f, 5f);
    }
}
