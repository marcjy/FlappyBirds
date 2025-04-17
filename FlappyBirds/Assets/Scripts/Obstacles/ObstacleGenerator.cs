using System.Collections;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public ObstacleManager[] ObstaclePrefabs;
    public float SecondsPerObstacle = 5.0f;

    private Coroutine _obstacleGenerator;

    private const int OBSTACLE_INITAL_POSITION_X = 10;
    private const int OBSTACLE_INITAL_POSITION_Y = 0;

    public void StartGenerator() => _obstacleGenerator = StartCoroutine(GenerateObstacle());
    public void StopGenerator()
    {
        StopCoroutine(_obstacleGenerator);
        _obstacleGenerator = null;
    }
    public void DestroyExistingObstacles()
    {
        ObstacleManager[] obstacles = FindObjectsByType<ObstacleManager>(FindObjectsSortMode.None);

        foreach (ObstacleManager obstacle in obstacles)
            Destroy(obstacle.gameObject);
    }


    private IEnumerator GenerateObstacle()
    {
        while (true)
        {
            Instantiate(GetRandomObstacle(), new Vector2(OBSTACLE_INITAL_POSITION_X, OBSTACLE_INITAL_POSITION_Y), Quaternion.identity);
            yield return new WaitForSeconds(SecondsPerObstacle);
        }
    }
    private ObstacleManager GetRandomObstacle() => ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Length - 1)];
}