using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    // �Ѿ��� ���ݷ�
    public float damage = 20.0f;
    // �Ѿ� �߻� ��
    public float force = 1500.0f;

    private Rigidbody rb;
    void Start()
    {
        /*
        // RigidBody ������Ʈ ����
        rb = GetComponent<Rigidbody>();

        // �Ѿ��� ���� �������� ��(Force)�� ����
        rb.AddForce(transform.forward * force);
        */
        // ���� ��ǥ�� ������ ���� �������� ���� ���Ѵ�.
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force);
    }

   
    void Update()
    {
        
    }
}
