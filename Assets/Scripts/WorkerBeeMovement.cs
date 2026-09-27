using UnityEngine;

public class WorkerBeeMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 2f;

    public WorkerBeeMovementType MovementType { get; set; } = WorkerBeeMovementType.Vertical;

    private Vector2 direction = Vector2.down;

    private bool isDestroing;
    
    private bool isMoving;

    private bool pickedHorizontalDirection = false;

    private void Start()
    {
        isMoving = true;
    }

    private void Update()
    {
        switch(MovementType)
        {
            case WorkerBeeMovementType.Vertical:
                MoveVertically();
                break;
            case WorkerBeeMovementType.Sway:
                MoveSwayly();
                break;
            case WorkerBeeMovementType.Horizontal:
                MoveHorizontally();
                break;
        }        
    }

    public void SetDestroing()
    {
        isDestroing = true;
    }

    public void StopMovement()
    {
        direction = Vector2.zero;
        isMoving = false;        
    }

    public void StartMovement(float newSpeed)
    {
        speed = newSpeed;   
        direction = Vector2.down;
        isMoving = true;
    }

    private void MoveVertically()
    {
        if (isMoving && !isDestroing)
        {
            transform.Translate(speed * Time.deltaTime * direction);
        }

    }

    private void MoveSwayly()
    {
        if (isMoving && !isDestroing)
        {
            float swayAmount = Mathf.Sin(Time.time * speed) * 4f;
            Vector2 swayDirection = new Vector2(swayAmount, -1f).normalized;
            transform.Translate(speed * Time.deltaTime * swayDirection);
        }
    }

    private void MoveHorizontally() 
    {
        if (isMoving && !isDestroing)
        {
            if (!pickedHorizontalDirection)
            {
                direction = transform.position.x >= 0 ? Vector2.left : Vector2.right;
                pickedHorizontalDirection = true;
            }
            transform.Translate(speed * Time.deltaTime * direction);
        }
    }
}
