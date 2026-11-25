using UnityEngine;
using UnityEngine.InputSystem;

public class RotateTowardMouse : MonoBehaviour
{
    private float angleOffset = 90f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotatePlayer();
    }
    
    void rotatePlayer()
    {
        if (Mouse.current == null || Camera.main == null) return;

        // Lấy tọa độ chuột bằng Input System mới
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

        // Chuyển sang tọa độ thế giới (gán z bằng khoảng cách từ camera tới vật thể)
        Vector3 screenPosWithZ = new Vector3(mouseScreenPos.x, mouseScreenPos.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z));
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(screenPosWithZ);

        Vector2 lookDir = mouseWorldPos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        // Áp dụng góc xoay kèm theo angleOffset (đã sửa để cộng thêm angleOffset)
        transform.rotation = Quaternion.Euler(0, 0, angle + angleOffset);
    }
}
