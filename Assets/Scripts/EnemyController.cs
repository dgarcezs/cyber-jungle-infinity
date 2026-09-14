using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Collider2D))]

[RequireComponent(typeof(Animator))]
public class EnemyController : MonoBehaviour
{

    private static readonly int DestroyHash = Animator.StringToHash("Destroy");
    private static readonly int AttackHash = Animator.StringToHash("Attack");

    [SerializeField ]
    private StingMachineContoller stingMachineContoller;

    public float speed = 3f; 
    public bool fireable = false;


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

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction, Space.World);
        if (fireable && GetToAttckPoint() && !isAttacking)
        {            
            animator.SetTrigger(AttackHash);            
            direction = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }        
        if (collider.CompareTag("ThunderBolt"))
        {
            isInExplosionMode = true;
            animator.SetTrigger(DestroyHash);            
        }
    }

    private bool GetToAttckPoint()
    {
        Vector3 position = gameObject.transform.position;
        float topBorder = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        return  (position.y < (topBorder - enemyCollider.bounds.size.y));
    }
}
