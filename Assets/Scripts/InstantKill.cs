using UnityEngine;

public class InstantKill : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();

        if (playerHealth != null && playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(playerHealth.currentHealth);
        }
    }
}