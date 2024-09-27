using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour // Este script va a ser para los Power Ups. Cambiar nombres y ajustar funcionalidad.
{

    [SerializeField] private Obstacle obstaclePrefab;
    [SerializeField] private float timeToSpawn;

    private List <Obstacle> obstacles = new List<Obstacle>();
    private float totalTime;

    private void Start()
    {
        for (int i = 0; i < 10; i++) //Instancio 10 obst�culos y los agrego a mi lista de obst�culos. Los inicializo desactivados y en el centro de la escena.
        {
            Obstacle obstacle = Instantiate(obstaclePrefab, Vector3.zero, Quaternion.identity); //Lo paso como la posicion del nuevo obst�culo.
            obstacles.Add(obstacle);
            obstacle.gameObject.SetActive(false);
        }
        SetRandomTimeToSpawn();
        totalTime = 0;
    }
    void Update()
    {
        if (!GameManager.isGameOn)
            return;

        totalTime += Time.deltaTime;
        if (totalTime > timeToSpawn) //Spawneo de obst�culos de acuerdo al tiempo transcurrido. Si el tiempo transcurrido supera el tiempo de spawneo (aleatorio), se spawnea el objeto.
        {
            SpawnObstacle();
            totalTime = 0;
            SetRandomTimeToSpawn();
        }
    }

    private void SpawnObstacle()
    {
        Vector2 randomPosition; //Posici�n aleatoria donde aparecer� el objeto.
        bool isBlockedPosition = false; //Variable bandera para chequear si est� bloqueada la posici�n por otro obst�culo.
        float radius = 1f; //Establezco una distancia m�nima entre los obst�culos.
        do
        {
            isBlockedPosition = false;
            randomPosition = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
            for (int i = 0; i < obstacles.Count; i++)
            {
                if (obstacles[i].gameObject.activeSelf) //Si est� activo...
                {
                    float distance = Vector3.Distance(randomPosition, obstacles[i].transform.position);
                    if(distance < radius * 2) //Si la distancia es menor que el di�metro de un obst�culo, significa que las posiciones se solapan. La bandera se activa y se corta el bucle.
                    {
                        isBlockedPosition = true;
                        break;
                    }
                }
            }
        } while (isBlockedPosition);
        for (int i = 0;i < obstacles.Count; i++)
        {
            if (!obstacles[i].gameObject.activeSelf) //Busco en mi lista de obst�culos uno que est� no est� activo.
            {
                obstacles[i].TurnOn(randomPosition); //Activo el obst�culo en la posici�n aleatoria.
                break;
            }
        }

    }

    private void SetRandomTimeToSpawn()
    {
        timeToSpawn = Random.Range(3f, 5f);
    }
}
