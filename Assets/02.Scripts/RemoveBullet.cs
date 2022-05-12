using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    // 충돌이 시작할 때 발생하는 이벤트
    public GameObject sparkEffect;

    void OnCollisionEnter(Collision collision)
    {
        // 첫 번째 충돌 지점의 정보 추출
        ContactPoint cp = collision.GetContact(0);
        // 충돌한 총알의 법선 벡터를 쿼터니언 타입으로 변환
        Quaternion rot = Quaternion.LookRotation(-cp.normal);
      
        // 충돌한 게임오브젝트의 태그값 비교
        if (collision.collider.CompareTag("BULLET")) 
        {
            // 스파크 파티클 동적으로 생성
            GameObject spark = Instantiate(sparkEffect, cp.point, rot);
            // 일정 시간이 지난 후 스파크 파티클 삭제
            Destroy(spark, 0.2f);
            // 충돌한 게임오브젝트 삭제
            Destroy(collision.gameObject);
        }
    }
}
