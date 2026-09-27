using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class EnemyController : MonoBehaviour
{
    private static readonly int FloatHash = Animator.StringToHash("Float");
    private static readonly int DestroyHash = Animator.StringToHash("Destroy");

    [SerializeField ]
    private StingMachineContoller stingMachineContoller;

    public float speed = 3f; 
    public bool fireable = false;

    private HealthManager healthManager;

    private Vector2 direction = Vector2.down;
    private Animator animator;
    private Collider2D enemyCollider;
    private bool isAttacking = false;    
    private bool isInExplosionMode = false;


    public void StartAttack()
    {
        direction = gameObject.transform.position.x >= 0 ? Vector2.left : Vector2.right;
        isAttacking = true;
    }

    public void FireStingMachine()
    {
        if (!isInExplosionMode) 
        {
            stingMachineContoller.FireSting();
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();    
        enemyCollider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        healthManager = GetComponent<HealthManager>();
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction, Space.World);
        if (fireable && GetToAttckPoint() && !isAttacking)
        {            
            animator.SetTrigger(FloatHash);            
            direction = Vector2.zero;
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

    private bool GetToAttckPoint()
    {
        Vector3 position = gameObject.transform.position;
        float topBorder = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        return  (position.y < (topBorder - enemyCollider.bounds.size.y));
    }

    private void OnHealthChange(int health)
    {
        if (health <= 0)
        {
            direction = Vector2.zero;
            isInExplosionMode = true;
            animator.SetTrigger(DestroyHash);
        }
    }
}
