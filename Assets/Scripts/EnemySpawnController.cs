using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public EnemyController enemyPrefab;

    private int enemyCount = 0;
    private readonly int maxEnemyCount = 1000;


    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, 1f);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnEnemy));
    }

    private void SpawnEnemy()
    {
        if (enemyCount < maxEnemyCount)
        {
            EnemyController enemyController = Instantiate(enemyPrefab, GetRandomPosition(), Quaternion.identity);
            enemyCount++;
        }
    }


    private Vector3 GetRandomPosition()
    {
        Vector3 leftBorder = Camera.main.ScreenToWorldPoint(new Vector3(0 + 50, 0, 0));
        Vector3 rightBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width -50, 0, 0));    
        return new Vector3(Random.Range(leftBorder.x, rightBorder.x), Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y , 0);
    }

    public void RemoveEnemy()
    {
        enemyCount--;
    }
}
