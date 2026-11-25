using UnityEngine;
using UnityEngine.InputSystem;

public class FlashlightController : MonoBehaviour
{
    private float angleOffset = 180f;

    void Update()
    {
        if (Camera.main == null) return;

        // Lấy vị trí chuột qua Input System mới
        Vector2 mouseScreenPos = Mouse.current != null ? Mouse.current.position.ReadValue() : Input.mousePosition;

        Vector3 screenPosWithZ = new Vector3(mouseScreenPos.x, mouseScreenPos.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z));
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(screenPosWithZ);

        // Tính hướng từ đèn tới vị trí chuột
        Vector2 direction = mouseWorldPos - transform.position;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;

        // Xoay đèn theo góc tính được
        transform.rotation = Quaternion.Euler(0, 0, targetAngle);
    }
}