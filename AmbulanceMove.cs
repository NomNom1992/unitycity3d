using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceMove : MonoBehaviour
{
    public float speed = 5f; // Tốc độ di chuyển của car
    private Vector3[] path; // Mảng chứa các tọa độ x và z
    private int currentIndex = 0; // Chỉ số của tọa độ hiện tại

    void Start()
    {
        // Khởi tạo mảng tọa độ
        path = new Vector3[10];
        for (int i = 0; i < 10; i++)
        {
            path[i] = new Vector3(50 + i * 10, 0, 117); // Tọa độ z tăng thêm 10 mỗi giây
        }

        // Bắt đầu di chuyển theo lộ trình
        StartCoroutine(MoveAlongPath());
    }

    IEnumerator MoveAlongPath()
    {
        while (currentIndex < path.Length)
        {
            // Lấy tọa độ tiếp theo
            Vector3 targetPosition = path[currentIndex];
            currentIndex++;

            // Di chuyển đến tọa độ tiếp theo
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }

            // Chờ 1 giây trước khi di chuyển tới tọa độ tiếp theo
            yield return new WaitForSeconds(1f);
        }
    }
}