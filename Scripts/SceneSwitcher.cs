using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneName; // 直接指定要跳的場景名稱（可選）
    public bool loadNextScene = true; // 如果 true 就用下一個場景

    private void OnTriggerEnter(Collider other)
    {
        // 檢查是否是玩家
        if (other.CompareTag("Player"))
        {
            if (loadNextScene)
            {
                // 取得當前場景的 build index
                int currentIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentIndex + 1);
            }
            else
            {
                // 直接用場景名稱切換
                if (!string.IsNullOrEmpty(sceneName))
                {
                    SceneManager.LoadScene(sceneName);
                }
            }
        }
    }
}
