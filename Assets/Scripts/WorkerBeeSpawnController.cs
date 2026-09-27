using UnityEngine;

public class WorkerBeeSpawnController : MonoBehaviour
{
    public WorkerBeeController workerBeePrefab;
    
    private int enemyCount = 0;
    private readonly int maxEnemyCount = 1000;

    private Vector3 topBorder;
    private Vector3 leftBorder;
    private Vector3 rightBorder;
    private readonly float positionOffset = 1;

    private void Start()
    {
        topBorder = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        leftBorder = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        rightBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));   
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnWorkerBee), 1f, 0.5f);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnWorkerBee));
    }

    private void SpawnWorkerBee()
    {
        if (enemyCount < maxEnemyCount)
        {
            enemyCount++;
            WorkerBeeController workerBeeController = Instantiate(workerBeePrefab, GetRandomHorizontalPosition(), Quaternion.identity);                      
            workerBeeController.WorkerBeeType = GetRandomWorkerBeeType();            
            workerBeeController.WorkerBeeBehaviour = WorkerBeeBehaviourFactory.GetWorkerBeeBehaviour(workerBeeController.WorkerBeeType);
        }
    }

    private Vector3 GetRandomHorizontalPosition()
    {
        return new Vector3(Random.Range(leftBorder.x + positionOffset, rightBorder.x - positionOffset), topBorder.y , 0);
    }

    WorkerBeeType GetRandomWorkerBeeType()
    {
        float random = Random.Range(0f, 100f);

        if (random < 70f)
            return WorkerBeeType.Common;

        if (random > 70f && random < 90f)
            return WorkerBeeType.Sway;

        return WorkerBeeType.Fire;
    }

    public void RemoveWorkerBee()
    {
        enemyCount--;
    }
}
