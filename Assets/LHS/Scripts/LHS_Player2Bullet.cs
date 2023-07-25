using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHS_Player2Bullet : MonoBehaviour
{
    //플레이어 위치에서 길이만큼 발사
    //닿으면 다시 나한테 돌아오기 Raycast Linecast 사용?


    // 다시 돌아올 타겟
    public Transform target;
    // 이동 속도
    public float speed = 5f;
    // 얘는 왜?
    public float returnSpeedMultiplier = 2f;

    public static bool isReturning = false;
    //간격 위치 저장
    private Vector3 initialPosition;

    private void Start()
    {
        //내 위치를 플레이어에 저장
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (!isReturning)
        {
            // Move towards the target using Lerp or SmoothDamp
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            // Check if the target has been reached
            if (transform.position == target.position)
            {
                //isReturning = true;
            }
        }
        else
        {
            // Return to the initial position with increased speed
            float step = speed * returnSpeedMultiplier * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, step);

            // Check if the initial position has been reached
            if (transform.position == initialPosition)
            {
                // Reset the boomerang effect
                isReturning = false;
            }
        }
    }
}
