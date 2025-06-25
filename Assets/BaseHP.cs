using UnityEngine;
using UnityEngine.UI;

public class BaseHP : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Slider healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Если танк врезался в базу — урон по столкновению
        if (collision.gameObject.CompareTag("Tank"))
        {
            TakeDamage(10f); // Урон от столкновения с танком
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Если пуля/снаряд врага попал в базу
        if (other.CompareTag("EnemyProjectile"))
        {
            TakeDamage(20f); // Урон от попадания врага
            Destroy(other.gameObject); // Удаляем снаряд
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        Debug.Log("Base health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("База разрушена!");
        // Здесь можно включить эффекты, конец игры и т.д.
    }

}