using UnityEngine;
using UnityEngine.InputSystem;

public class ThunderBoltMachineController : MonoBehaviour
{
    
    public ThunderBoltController thunderBoltPrefab;

    [SerializeField]
    private InputActionReference shootAction;

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
    }


    public void TriggerThunderBolt(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            Debug.Log("Triggered one thunder bolt");
            ThunderBoltController newThunderBolt = Instantiate(thunderBoltPrefab, transform.position, Quaternion.identity);
        }
    }
}
