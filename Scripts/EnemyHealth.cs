using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public GameObject healthBarPrefab;
    private Slider healthSlider;
    private Transform healthBar;

    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;

        GameObject bar = Instantiate(healthBarPrefab, transform.position + Vector3.up * 2f, Quaternion.identity);
        healthBar = bar.transform;
        healthSlider = bar.GetComponentInChildren<Slider>();

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    void Update()
    {
        if (healthBar != null)
        {
            healthBar.position = transform.position + Vector3.up * 2f;
            healthBar.forward = Camera.main.transform.forward;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        healthSlider.value = currentHealth;

        Debug.Log("¼Ä¤H¦©¦å¡A³Ñ¾l¦å¶q¡G" + currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(healthBar.gameObject);
            Destroy(gameObject);
        }
    }
}
