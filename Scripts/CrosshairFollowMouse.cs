using UnityEngine;

public class CrosshairCenter : MonoBehaviour
{
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Cursor.visible = false;
    }

    void Update()
    {
        // ¿Ã¹õ¤¤¤ßÂI
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        rectTransform.position = screenCenter;
    }
}
