using System.Collections;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private int startHealth = 1;

    [SerializeField]
    private int maxHealth = 1;

    [SerializeField]
    private float invulnerabilityInterval = 1f;

    public int Health { get; private set; }

    private bool isInvulnerable = false;

    private void Start()
    {
        Health = startHealth;
    }

    public void Damage(int amount)
    {
        if (!isInvulnerable)
        {
            if (Health > 0)
            {
                Health -= amount;
            }
            
            SendMessage("OnHealthChange", Health, SendMessageOptions.RequireReceiver);
            
            if (invulnerabilityInterval > 0 && Health > 0)
            { 
                StartCoroutine(InvulnerabilityCoroutine());
            }
        }
    }

    public void Heal(int amount)
    {
        if (Health + amount < maxHealth) 
        {
            Health += amount;
        }
        else
        {
            Health = maxHealth;
        }
        SendMessage("OnHealthChange", Health, SendMessageOptions.DontRequireReceiver);
    }

    private IEnumerator InvulnerabilityCoroutine()
    {
        isInvulnerable = true;
        SendMessage("OnInvulnerabilityStart", SendMessageOptions.DontRequireReceiver);

        yield return new WaitForSeconds(invulnerabilityInterval);

        isInvulnerable = false;
        SendMessage("OnInvulnerabilityEnd", SendMessageOptions.DontRequireReceiver);
    }
}

