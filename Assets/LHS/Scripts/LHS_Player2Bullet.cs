using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHS_Player2Bullet : MonoBehaviour
{
    //�÷��̾� ��ġ���� ���̸�ŭ �߻�
    //������ �ٽ� ������ ���ƿ��� Raycast Linecast ���?


    // �ٽ� ���ƿ� Ÿ��
    public Transform target;
    // �̵� �ӵ�
    public float speed = 5f;
    // ��� ��?
    public float returnSpeedMultiplier = 2f;

    public static bool isReturning = false;
    //���� ��ġ ����
    private Vector3 initialPosition;

    private void Start()
    {
        //�� ��ġ�� �÷��̾ ����
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
