using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    // �浹�� ������ �� �߻��ϴ� �̺�Ʈ
    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ���ӿ�����Ʈ�� �±װ� ��
        if (collision.collider.CompareTag("BULLET")) 
        {
            // �浹�� ���ӿ�����Ʈ ����
            Destroy(collision.gameObject);
        }
    }
}
