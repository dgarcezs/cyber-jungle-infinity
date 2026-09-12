using UnityEngine;

public class ThunderBoltController : MonoBehaviour
{

    private readonly string EnemyTag = "Enemy";
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(EnemyTag))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }                
    }
}
