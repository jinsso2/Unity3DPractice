using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ݵ�� �ʿ��� ������Ʈ�� ����� �ش� ������Ʈ�� �����Ǵ� ���� �����ϴ� ��Ʈ����Ʈ
[RequireComponent(typeof(AudioSource))]
public class FireCtrl : MonoBehaviour
{
    // �Ѿ� ������
    public GameObject bullet;
    // �Ѿ��� �߻�� ��ǥ
    public Transform firePos;
    // �ѼҸ��� ����� ����� ����
    public AudioClip fireSfx;


    // AudioSource ������Ʈ�� ������ ����
    private new AudioSource audio;
    // Muzzle Flash�� MeshRenderer ������Ʈ
    private MeshRenderer muzzleFlash;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        // FirePos ������ �ִ� MuzzleFlash�� Material ������Ʈ�� ����
        muzzleFlash = firePos.GetComponentInChildren<MeshRenderer>();
        // ó�� ������ �� ��Ȱ��ȭ
        muzzleFlash.enabled = false;
    }

   
    void Update()
    {
        // ���콺 ���� ��ư�� Ŭ������ �� Fire �Լ� ȣ��
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        // Bullet �������� �������� ����Instantiate(������ ��ü, ��ġ, ȸ��)
        Instantiate(bullet, firePos.position, firePos.rotation);
        // �ѼҸ� �߻�
        audio.PlayOneShot(fireSfx, 1.0f);
        // �ѱ� ȭ�� ȿ�� �ڷ�ƾ �Լ� ȣ��
        StartCoroutine(ShowMuzzleFlash());
    }

    IEnumerator ShowMuzzleFlash()
    {
        // -- �ѱ� ȭ�� �ؽ�ó�� ������ ���� ȸ�� ���� �ٲ� �����ϰ� �ѱ� ȭ�� ǥ��
        // ������ ��ǩ���� ���� �Լ��� ���� �� �ؽ�ó�� ������ �� ����
        // Random.Range(0, 2) �� ��ȯ�ϴ� ������ 0, 1�̰� �� ���� 0.5f�� ���ϸ� (0.0f, 0.5f) �� �� �ϳ��� �ȴ�. �� ������ �ؽ�ó�� ǥ���� ���� ����
        Vector2 offset = new Vector2(Random.Range(0, 2), Random.Range(0, 2) * 0.5f);
        muzzleFlash.material.mainTextureOffset = offset;

        // ������ �����Լ��� ���� �� MuzzleFlash�� ȸ�� ����
        float angle = Random.Range(0, 360);
        muzzleFlash.transform.localRotation = Quaternion.Euler(0, 0, angle);

        // MuzzleFalsh�� ũ�� ����
        float scale = Random.Range(1.0f, 2.0f);
        muzzleFlash.transform.localScale = Vector3.one * scale;
        
        // MuzzleFlash Ȱ��ȭ
        muzzleFlash.enabled = true;

        // 0.2�� ���� ����ϴ� ���� �޽��� ������ ������� �纸
        yield return new WaitForSeconds(0.2f);

        // MuzzleFlash ��Ȱ��ȭ
        muzzleFlash.enabled = false;
    }
}
