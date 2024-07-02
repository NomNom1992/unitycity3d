using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 10f;
    public float sensitivity = 2f;

    private float rotationY = 0f;
    private float rotationX = 0f;

    void Update()
    {
        // Di chuyển camera bằng các phím WASD
        float translationX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float translationZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(translationX, 0, translationZ);

        // Điều khiển góc nhìn bằng chuột khi nhấn giữ chuột phải
        if (Input.GetMouseButton(1)) // 1 là nút chuột phải
        {
            rotationY += Input.GetAxis("Mouse X") * sensitivity;
            rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            rotationX = Mathf.Clamp(rotationX, -90, 90); // Giới hạn góc nhìn lên và xuống
        }

        // Cập nhật góc nhìn của camera
        transform.eulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}