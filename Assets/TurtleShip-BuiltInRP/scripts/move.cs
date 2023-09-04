using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class move : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private void Update()
    {
        // 키보드 입력을 받아 캐릭터 움직임 계산
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        moveDirection.Normalize();

        // 캐릭터의 위치를 움직임 방향과 속도를 곱한 값으로 업데이트
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        //캐릭터의 움직임 방향을 바라보도록 회전
        //if (moveDirection != Vector3.zero)
        //{
        //    Quaternion newRotation = Quaternion.LookRotation(moveDirection);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10.0f);
        //}

        // 현재 캐릭터의 회전값을 가져옴
        Quaternion currentRotation = transform.rotation;

        // 북쪽을 나타내는 회전값을 계산
        Quaternion targetRotation = Quaternion.Euler(0, 0, 0); // (x, y, z) 각도를 지정

        // 회전값을 부드럽게 보간하여 업데이트
        transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * 5.0f);
    }
}