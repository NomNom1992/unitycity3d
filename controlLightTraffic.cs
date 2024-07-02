using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class controlLightTraffic : MonoBehaviour
{
    public TextMeshProUGUI stateText; // Tham chiếu đến thành phần TextMesh Pro UI
    public float redDuration = 10f;
    public float yellowDuration = 3f;
    public float greenDuration = 10f;
    public Camera mainCamera; // Tham chiếu đến camera chính

    private float timer;
    private string currentState;

    void Start()
    {
        // Khởi tạo đèn giao thông bắt đầu với màu đỏ
        currentState = "Red";
        timer = redDuration;
        UpdateStateText();
    }

    void Update()
    {
        // Đếm ngược thời gian
        timer -= Time.deltaTime;
        UpdateStateText();

        // Kiểm tra nếu thời gian đếm ngược đã hết và chuyển sang trạng thái tiếp theo
        if (timer <= 0)
        {
            SwitchState();
        }

        // Luôn hướng text về phía camera
        stateText.transform.LookAt(stateText.transform.position + mainCamera.transform.rotation * Vector3.forward, mainCamera.transform.rotation * Vector3.up);
    }

    void SwitchState()
    {
        if (currentState == "Red")
        {
            currentState = "Green";
            timer = greenDuration;
        }
        else if (currentState == "Green")
        {
            currentState = "Yellow";
            timer = yellowDuration;
        }
        else if (currentState == "Yellow")
        {
            currentState = "Red";
            timer = redDuration;
        }

        UpdateStateText();
    }

    void UpdateStateText()
    {
        // Cập nhật Text UI để hiển thị trạng thái hiện tại và thời gian đếm ngược
        stateText.text = $"{currentState} - {Mathf.Ceil(timer)}s";

        // Cập nhật màu của Text UI dựa trên trạng thái hiện tại
        switch (currentState)
        {
            case "Red":
                stateText.color = Color.red;
                break;
            case "Yellow":
                stateText.color = Color.yellow;
                break;
            case "Green":
                stateText.color = Color.green;
                break;
        }
    }
}
