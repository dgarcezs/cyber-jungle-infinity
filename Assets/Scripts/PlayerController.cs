using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private InputActionReference moveAction;

    public Vector2 Direction {get; private set;} = Vector2.zero;

    private Collider2D playerCollider;

    private void Start()
    {
        playerCollider = GetComponent<Collider2D>();
    }    

    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.Translate(speed * Time.deltaTime * Direction);
        transform.position = BoxedIntoScreen();
    }

    public void GetDirection(InputAction.CallbackContext context)
    {
        Direction = context.ReadValue<Vector2>().normalized;
    }

    private Vector3 BoxedIntoScreen()
    {
        Vector3 boxedPosition = transform.position;
        Vector3 maxScreenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector3 minScreenPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

        minScreenPosition.x += playerCollider.bounds.extents.x;
        minScreenPosition.y += playerCollider.bounds.extents.y;
        maxScreenPosition.x -= playerCollider.bounds.extents.x;
        maxScreenPosition.y -= playerCollider.bounds.extents.y;

        boxedPosition.x = Mathf.Clamp(boxedPosition.x, minScreenPosition.x, maxScreenPosition.x);
        boxedPosition.y = Mathf.Clamp(boxedPosition.y, minScreenPosition.y, maxScreenPosition.y);

        return boxedPosition;
    }    



}
