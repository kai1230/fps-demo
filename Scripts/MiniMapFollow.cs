using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y; // 保持高度不變
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f); // 只跟隨Y軸旋轉
    }
}
