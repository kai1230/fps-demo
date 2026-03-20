using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;

    CharacterController controller;
    Camera playerCamera;
    float verticalRotation = 0f;

    void Start()
    {
        // 開始時鎖定滑鼠並隱藏游標
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
        playerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 按下 Esc → 解鎖滑鼠、顯示游標
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        // 移動
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = transform.right * h + transform.forward * v;
        controller.SimpleMove(move * moveSpeed);

        // 滑鼠視角
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(0, mouseX, 0);
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}
