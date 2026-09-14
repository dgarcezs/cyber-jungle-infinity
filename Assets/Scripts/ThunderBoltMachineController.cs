using UnityEngine;
using UnityEngine.InputSystem;

public class ThunderBoltMachineController : MonoBehaviour
{
    
    public ThunderBoltController thunderBoltPrefab;

    [SerializeField]
    private InputActionReference shootAction;

    private float coolingdown = 0.3f;
    private float coolingdownTimer = 0.0f;

    private bool isCoolingdown = false;


    // Update is called once per frame
    private void Update()
    {
        coolingdownTimer += Time.deltaTime;
        if (coolingdownTimer >= coolingdown)
        {
            isCoolingdown = false;
            coolingdownTimer = 0.0f;
        }
    }

    public void TriggerThunderBolt(InputAction.CallbackContext context)
    {
        if (context.performed && !isCoolingdown) 
        {
            ThunderBoltController newThunderBolt = Instantiate(thunderBoltPrefab, transform.position, Quaternion.identity);
            isCoolingdown = true;
            coolingdownTimer = 0.0f;
        }
    }
}
