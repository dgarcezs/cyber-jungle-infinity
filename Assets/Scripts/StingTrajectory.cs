using UnityEngine;

public class StingTrajectory : MonoBehaviour
{
    private float speed = 10f;
    private Vector2 direction = Vector2.down;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction, Space.World);                
    }
}
