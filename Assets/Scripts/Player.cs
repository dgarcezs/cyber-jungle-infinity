using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private static readonly int DeadHash = Animator.StringToHash("dead");
    private static readonly int TakeDamageHash = Animator.StringToHash("take_damage");                                                                        
    private static readonly int HorizontalDirectionHash = Animator.StringToHash("horizontal_direction");
    private static readonly int VerticalDirectionHash = Animator.StringToHash("vertical_direction");
    
    private Animator animator;
    private PlayerController playerController;   
    private ThunderBoltMachineController thunderBoltMachineController;

    private Collider2D collider;

    private void Start()
    {
        animator = GetComponent<Animator>();    
        collider  = GetComponent<Collider2D>();
        playerController = GetComponent<PlayerController>();        
        thunderBoltMachineController = GetComponentInChildren<ThunderBoltMachineController>();
    }

    private void Update()
    {
        animator.SetFloat(HorizontalDirectionHash, playerController.Direction.x);
        animator.SetFloat(VerticalDirectionHash, playerController.Direction.y);
    }

    private void OnHealthChange(int health)
    {
        if (health > 0)
        {
            animator.SetTrigger(TakeDamageHash);            
        }
        else
        {
            DisablePlayer();
            ExplodePlayer();
        }         
    }

    private void OnInvulnerabilityStart()
    {
        animator.SetBool("invulnerable", true);
    }

    private void OnInvulnerabilityEnd()
    {
        animator.SetBool("invulnerable", false);
    }

    private void ExplodePlayer()
    {        
        animator.SetTrigger(DeadHash);
        Invoke(nameof(GameOver), 2f);        
    }

    private void GameOver()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void DisablePlayer()
    {
        collider.enabled = false;
        playerController.enabled = false;
        thunderBoltMachineController.enabled = false;
    }

}
