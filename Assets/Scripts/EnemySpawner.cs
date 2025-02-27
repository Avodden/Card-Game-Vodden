using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy prefab to spawn
    public int numberOfEnemies = 10; // Number of enemies to spawn
    public Vector3 roomMin; // Minimum boundary of the room
    public Vector3 roomMax; // Maximum boundary of the room
    public float minDistance = 2f; // Minimum distance between enemies

    private List<Vector3> enemyPositions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 randomPosition;
            bool validPosition;

            do
            {
                randomPosition = new Vector3(
                    Random.Range(roomMin.x, roomMax.x),
                    Random.Range(roomMin.y, roomMax.y),
                    Random.Range(roomMin.z, roomMax.z)
                );

                validPosition = true;
                foreach (Vector3 pos in enemyPositions)
                {
                    if (Vector3.Distance(randomPosition, pos) < minDistance)
                    {
                        validPosition = false;
                        break;
                    }
                }
            } while (!validPosition);

            enemyPositions.Add(randomPosition);
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
