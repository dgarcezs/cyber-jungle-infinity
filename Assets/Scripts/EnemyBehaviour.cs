using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private float speed =3f;
    private Vector2 direction = Vector2.down;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction, Space.World);
    }
}
