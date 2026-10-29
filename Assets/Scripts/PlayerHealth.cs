using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public Slider healthBar;
    public GameObject gameOverUI;

    private bool isDead = false;
    void Start()
    {
        currentHealth = maxHealth;

        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void TakeDamage(float damage)
    {
        if (isDead)
            return;

        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        Debug.Log("Player Died!");

        gameOverUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Stop player controls
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        // Stop walking/running animation
        Animator animator = GetComponent<Animator>();

        if (animator != null)
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isSprinting", false);
            animator.SetBool("isCrouching", false);
            animator.SetBool("isJumping", false);
        }
    }
}