using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public EnemyController enemyPrefab;
    
    private int enemyCount = 0;
    private readonly int maxEnemyCount = 1000;

    private Vector3 topBorder;
    private Vector3 leftBorder;
    private Vector3 rightBorder;
    private float positionOffset = 1;

    private void Start()
    {
        topBorder = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        leftBorder = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        rightBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));   
    }

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
            enemyCount++;
            EnemyController enemyController = Instantiate(enemyPrefab, GetRandomPosition(), Quaternion.identity);
            enemyController.speed = Random.Range(3, 5);
            enemyController.fireable = (enemyCount % 5) == 0;            
        }
    }


    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(leftBorder.x + positionOffset, rightBorder.x - positionOffset), topBorder.y , 0);
    }

    public void RemoveEnemy()
    {
        enemyCount--;
    }
}
