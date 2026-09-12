using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private static readonly int HorizontalDirectionHash = Animator.StringToHash("horizontal_direction");
    private static readonly int VerticalDirectionHash = Animator.StringToHash("vertical_direction");
    private Animator animator;
    private PlayerController playerController;

    private void Start()
    {
        animator = GetComponent<Animator>();    
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        animator.SetFloat(HorizontalDirectionHash, playerController.Direction.x);
        animator.SetFloat(VerticalDirectionHash, playerController.Direction.y);
    }
}
