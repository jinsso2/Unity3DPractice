using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField]
    private Transform tr;   // ������Ʈ�� ĳ�� ó���� ����
    private Animation anim; // Animation ������Ʈ�� ������ ����

    public float moveSpd = 10.0f;   // �̵��ӵ� ���� (public���� ó���� �ν����� â�� �����)
    public float turnSpd = 80.0f;   // ȸ�� �ӵ� ����

    void Start()
    {
        // Transform ������Ʈ�� ������ ������ ����
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();

        anim.Play("Idle");    // �ִϸ��̼� ����
    }


    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

         Debug.Log("h=" + h);
         Debug.Log("v=" + v);

        /*
        // Transform ������Ʈ�� position �Ӽ����� ����
        // transform.position += Vector3.forward * 1;

        // ����ȭ ���͸� ����� �ڵ�
        // tr.position += Vector3.forward * 1;

        // Translate �Լ��� ����� �̵� ����
        tr.Translate(Vector3.forward * Time.deltaTime * v * moveSpd);
        */

        // �����¿� �̵� ���� ���� ���
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        // Translate(�̵� ���� * �ӷ� * Time.deltatime)
        tr.Translate(moveDir * moveSpd * Time.deltaTime);

        // Vector3.up ���� �������� turnSpd ��ŭ�� �ӵ��� ȸ��
        tr.Rotate(Vector3.up * turnSpd * Time.deltaTime * r);

        // ���ΰ� ĳ������ �ִϸ��̼� ����
        PlayerAnim(h, v);
    }

    void PlayerAnim(float h, float v)
    {
        // Ű���� �Է°��� �������� ������ �ִϸ��̼� ����

        if (v >= 0.1f)
        {
            anim.CrossFade("RunF", 0.25f);  // ����
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade("RunB", 0.25f);  // ����
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade("RunR", 0.25f);  // ������
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade("RunL", 0.25f);  // ����
        }
        else
        {
            anim.CrossFade("Idle", 0.25f);  // ���� �� Idle
        }
    }
}
