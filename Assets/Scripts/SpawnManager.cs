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
        for (int i = 0; i < 10; i++)
        {
            Obstacle obstacle = Instantiate(obstaclePrefab, Vector3.zero, Quaternion.identity); //Lo paso como la posicion del nuevo obstáculo.
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
        if (totalTime > timeToSpawn)
        {
            SpawnObstacle();
            totalTime = 0;
            SetRandomTimeToSpawn();
        }
    }

    private void SpawnObstacle()
    {
        Vector2 randomPosition;
        bool isBlockedPosition = false;
        float radius = 1f;
        do
        {
            isBlockedPosition = false;
            randomPosition = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
            for (int i = 0; i < obstacles.Count; i++)
            {
                if (obstacles[i].gameObject.activeSelf)
                {
                    float distance = Vector3.Distance(randomPosition, obstacles[i].transform.position);
                    if(distance < radius * 2)
                    {
                        isBlockedPosition = true;
                        break;
                    }
                }
            }
        } while (isBlockedPosition);
        for (int i = 0;i < obstacles.Count; i++)
        {
            if (!obstacles[i].gameObject.activeSelf)
            {
                obstacles[i].TurnOn(randomPosition);
                break;
            }
        }

    }

    private void SetRandomTimeToSpawn()
    {
        timeToSpawn = Random.Range(3f, 5f);
    }
}
