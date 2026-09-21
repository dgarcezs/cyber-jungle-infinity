using UnityEngine;

public class ThunderBoltController : MonoBehaviour
{

    private readonly string EnemyTag = "Enemy";
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(EnemyTag))
        {
            if (collision.TryGetComponent<HealthManager>(out var enemyHealtManager))
            {
                enemyHealtManager.Damage(1);
                Destroy(gameObject);
            }            
        }                
    }
}
