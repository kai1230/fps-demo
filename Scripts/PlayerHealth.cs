using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public TextMeshProUGUI healthText; // 拖入 UI 顯示血量

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth + " / " + maxHealth;
        }
    }

    void Die()
    {
        Debug.Log("玩家死亡");

        // 暫停時間（可選）
        Time.timeScale = 0f;

        // 退出遊戲（只在 Build 出來的遊戲執行檔有效）
        Application.Quit();

#if UNITY_EDITOR
        // 如果你在 Unity 編輯器測試，也讓它「假裝退出」
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
