using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class WorkerBeeController : MonoBehaviour
{
    private static readonly int DestroyHash = Animator.StringToHash("destroy");

    public WorkerBeeType WorkerBeeType { get; set; }  
    public WorkerBeeBehaviour WorkerBeeBehaviour { get; set; }

    private Animator animator;
    private WorkerBeeMovement workerBeeMovement;

    private Collider2D collider;

    private void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        workerBeeMovement = GetComponent<WorkerBeeMovement>();        
    }

    private void OnDistanceReached()
    {
        StartCoroutine(PerformBehaviourCoroutine());
    }

    private IEnumerator PerformBehaviourCoroutine()
    {
        if (WorkerBeeBehaviour == null || WorkerBeeBehaviour.Actions == null)
        {
            yield break;
        }

        foreach (var action in WorkerBeeBehaviour.Actions)
        {
            switch (action.ActionName)
            {
                case WorkerBeeActionType.Idle:
                    workerBeeMovement.StopMovement();
                    animator.SetTrigger("turn_up");
                    break;
                case WorkerBeeActionType.Attack:
                    workerBeeMovement.StopMovement();
                    animator.SetTrigger("flight_attack");
                    workerBeeMovement.MovementType = WorkerBeeMovementType.Vertical;
                    workerBeeMovement.StartMovement(5f);
                    break;
                case WorkerBeeActionType.Sway:
                    workerBeeMovement.StopMovement();
                    animator.SetTrigger("turn_up");
                    workerBeeMovement.MovementType = WorkerBeeMovementType.Sway;
                    workerBeeMovement.StartMovement(5f);
                    break;
                case WorkerBeeActionType.Shoot:
                    workerBeeMovement.StopMovement();
                    animator.SetTrigger("turn_up");
                    workerBeeMovement.MovementType = WorkerBeeMovementType.Horizontal;
                    workerBeeMovement.StartMovement(2f);
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(action.ActionDuration);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (collider.TryGetComponent<HealthManager>(out var playerHealthManager))
            {
                playerHealthManager.Damage(1);
                Destroy(gameObject);
            }
        }
    }

    private void OnHealthChange(int health)
    {
        if (health <= 0)
        {
            StartCoroutine(OnDestroyCoroutine());
        }
    }

    private IEnumerator OnDestroyCoroutine()
    {
        collider.enabled = false;
        workerBeeMovement.SetDestroing();
        animator.SetTrigger(DestroyHash);
        int destroyLayerIndex = animator.GetLayerIndex("Destroy");
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(destroyLayerIndex).IsName("Explosion"));        
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(destroyLayerIndex).normalizedTime >= 1f);
        Destroy(gameObject);
    }
}