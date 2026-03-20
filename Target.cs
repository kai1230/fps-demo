using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public GameObject healthBarPrefab;    // 血條 Prefab (World Space Canvas)
    private Slider healthSlider;          // 血條裡的Slider
    private GameObject healthBarInstance; // 血條實例

    private Transform healthBarTransform;

    void Start()
    {
        currentHealth = maxHealth;

        // 在敵人頭上生成血條Prefab，並取得Slider元件
        healthBarInstance = Instantiate(healthBarPrefab, transform.position + Vector3.up * 2f, Quaternion.identity);
        healthBarTransform = healthBarInstance.transform;

        healthSlider = healthBarInstance.GetComponentInChildren<Slider>();
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    void Update()
    {
        if (healthBarInstance != null)
        {
            // 血條跟隨敵人頭頂位置
            healthBarTransform.position = transform.position + Vector3.up * 2f;

            // 讓血條面向主攝影機
            healthBarTransform.rotation = Quaternion.LookRotation(healthBarTransform.position - Camera.main.transform.position);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // 更新血條
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        Debug.Log($"Enemy HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 銷毀血條與敵人
        if (healthBarInstance != null)
            Destroy(healthBarInstance);

        Destroy(gameObject);
        Debug.Log("Enemy died!");
    }
}
