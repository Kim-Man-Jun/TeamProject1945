using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//1�ܰ� ��
//�÷��̾ ����ٴѴ� -> ������ ������ �д� (�ִϸ��̼�)
//���� �߻��Ѵ�.
public class LHS_Monster1 : MonoBehaviour
{
    [Header("�̵��ӵ�")]
    [SerializeField] float speed;

    GameObject target;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    { 
        #region �ִϸ��̼�
        //������ ���� �̿��� �ִϸ��̼� ó��
        //�÷��̾ ��� �����ʿ� �ִ��� üũ 
        //���� �ִϸ��̼� �ٲٱ�
        Vector3 dir = target.transform.position - transform.position;

        if(dir.x > 0.5f )
        {
            //+ ���������� ������
            anim.SetBool("Right", true);
        }
        else
        {
            anim.SetBool("Right", false);
        }
        if (dir.x < 0.5f)
        {
            anim.SetBool("Left", true);
        }
        else
        {
            anim.SetBool("Left", false);
        }
        #endregion

        //transform.position = Vector3.Lerp(transform.position, target.transform.position - new Vector3(2, 0, 0), speed);

        transform.Translate(dir * speed * Time.deltaTime);
    }
}
