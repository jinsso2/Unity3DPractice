using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    // 총알의 공격력
    public float damage = 20.0f;
    // 총알 발사 힘
    public float force = 1500.0f;

    private Rigidbody rb;
    void Start()
    {
        /*
        // RigidBody 컴포넌트 추출
        rb = GetComponent<Rigidbody>();

        // 총알이 전진 방향으로 힘(Force)을 가함
        rb.AddForce(transform.forward * force);
        */
        // 로컬 좌표계 기준의 전진 방향으로 힘을 가한다.
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force);
    }

   
    void Update()
    {
        
    }
}
