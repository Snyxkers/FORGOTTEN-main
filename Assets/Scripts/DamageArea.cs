using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public float damagePerSecond = 10f;

    private void OnTriggerStay(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }
}