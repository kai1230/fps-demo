using TMPro;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public TextMeshProUGUI enemyText;

    void Update()
    {
        // 每一幀統計場上敵人
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyText.text = "Enemies: " + enemyCount;
    }
}
