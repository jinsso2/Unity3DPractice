using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    // ���� ȿ�� ��ƼŬ�� ������ ����
    public GameObject expEffect;

    // �������� ������ �ؽ�ó �迭
    public Texture[] textures;

    // ���� �ݰ�
    public float radius = 10.0f;
    
    // ������ �ִ� Mesh Renderer ������Ʈ�� ������ ����
    private new MeshRenderer renderer;

    // ������Ʈ�� ������ ����
    private Transform tr;
    private Rigidbody rb;

    // �Ѿ��� ���� Ƚ���� ������ų ����
    private int hitCount = 0;

    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        // ������ �ִ� Mesh Renderer ������Ʈ ����
        renderer = GetComponentInChildren<MeshRenderer>();

        // ���� �߻�
        int idx = Random.Range(0, textures.Length);
        // �ؽ�ó ����
        renderer.material.mainTexture = textures[idx];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BULLET"))
        {
            // �Ѿ��� ���� Ƚ���� ������Ű�� 3ȸ �̻��̸� ���� ó��
            if(++hitCount == 3)
            {
                ExpBarrel();
            }
        }
    }

    void ExpBarrel()
    {
        // ���� ȿ�� ��ƼŬ ����
        GameObject exp = Instantiate(expEffect, tr.position, Quaternion.identity);
        // ���� ȿ�� ��ƼŬ ���� �ð� �Ŀ� ����
        Destroy(exp, 0.5f);

        /*
        // Rigidbody ������Ʈ�� mass�� 1.0���� ������ ���Ը� ������ ��
        rb.mass = 1.0f;
        // ���� �ڱ�ġ�� ���� ����
        rb.AddForce(Vector3.up * 1500.0f);
        */

        // ���� ���߷� ����
        IndirectDamage(tr.position);
        // 3�� �Ŀ� �巳�� ����
        Destroy(gameObject, 3.0f);
    }
    
    // �ᱣ���� ������ ���� �迭 �̸� ����
    Collider[] colls = new Collider[10];

    // �ֺ��� ������Ʈ�� ������ ���߷��� �����ϴ� �Լ�
    void IndirectDamage(Vector3 pos)    
    {
        // �ֺ��� �ִ� �巳���� ��� ����
        // ������ �÷��� �߻�
        // Collider[] colls = Physics.OverlapSphere(pos, radius, 1 << 3);

        // ������ �÷����� �߻����� ����
        Physics.OverlapSphereNonAlloc(pos, radius, colls, 1 << 3);
        foreach (var coll in colls)
        {
            // ���� ������ ���Ե� �巳���� Rigidbody ������Ʈ ����
            rb = coll.GetComponent<Rigidbody>();
            // ���Ը� ������ ��
            rb.mass = 1.0f;
            // freezeRotation ���Ѱ� ����
            rb.constraints = RigidbodyConstraints.None;
            // ���߷� ����
            rb.AddExplosionForce(1500.0f, pos, radius, 1200.0f);
        }
    }
}