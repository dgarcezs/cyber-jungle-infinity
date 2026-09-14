using UnityEngine;
using UnityEngine.SceneManagement;

public class StingController : MonoBehaviour
{
    private readonly string PlayerTag = "Player";
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerTag))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }                
    }
}
