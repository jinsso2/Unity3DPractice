using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    // �浹�� ������ �� �߻��ϴ� �̺�Ʈ
    public GameObject sparkEffect;

    void OnCollisionEnter(Collision collision)
    {
        // ù ��° �浹 ������ ���� ����
        ContactPoint cp = collision.GetContact(0);
        // �浹�� �Ѿ��� ���� ���͸� ���ʹϾ� Ÿ������ ��ȯ
        Quaternion rot = Quaternion.LookRotation(-cp.normal);
      
        // �浹�� ���ӿ�����Ʈ�� �±װ� ��
        if (collision.collider.CompareTag("BULLET")) 
        {
            // ����ũ ��ƼŬ �������� ����
            GameObject spark = Instantiate(sparkEffect, cp.point, rot);
            // ���� �ð��� ���� �� ����ũ ��ƼŬ ����
            Destroy(spark, 0.2f);
            // �浹�� ���ӿ�����Ʈ ����
            Destroy(collision.gameObject);
        }
    }
}
