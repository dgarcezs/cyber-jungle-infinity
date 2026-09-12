using UnityEngine;

public class ThunderBoltTrajectory : MonoBehaviour
{

    private float speed = 15f;
    private Vector2 direction = Vector2.up;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction, Space.World);                
    }
}
