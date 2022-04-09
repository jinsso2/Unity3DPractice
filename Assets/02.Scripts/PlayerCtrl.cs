using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField]
    private Transform tr;   // 컴포넌트를 캐시 처리할 변수
    private Animation anim; // Animation 컴포넌트를 저장할 변수

    public float moveSpd = 10.0f;   // 이동속도 변수 (public으로 처리해 인스펙터 창에 노출됨)
    public float turnSpd = 80.0f;   // 회전 속도 변수

    void Start()
    {
        // Transform 컴포넌트를 추출해 변수에 대입
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();

        anim.Play("Idle");    // 애니메이션 실행
    }


    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        // Debug.Log("h=" + h);
        // Debug.Log("v=" + v);

        /*
        // Transform 컴포넌트의 position 속성값을 변경
        // transform.position += Vector3.forward * 1;

        // 정규화 벡터를 사용한 코드
        // tr.position += Vector3.forward * 1;

        // Translate 함수를 사용한 이동 로직
        tr.Translate(Vector3.forward * Time.deltaTime * v * moveSpd);
        */

        // 전후좌우 이동 방향 벡터 계산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        // Translate(이동 방향 * 속력 * Time.deltatime)
        tr.Translate(moveDir * moveSpd * Time.deltaTime);

        // Vector3.up 축을 기준으로 turnSpd 만큼의 속도로 회전
        tr.Rotate(Vector3.up * turnSpd * Time.deltaTime * r);

        // 주인공 캐릭터의 애니메이션 결정
        PlayerAnim(h, v);
    }

    void PlayerAnim(float h, float v)
    {
        // 키보드 입력값을 기준으로 동작할 애니메이션 수행

        if (v >= 0.1f)
        {
            anim.CrossFade("RunF", 0.25f);  // 전진
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade("RunB", 0.25f);  // 후진
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade("RunR", 0.25f);  // 오른쪽
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade("RunL", 0.25f);  // 왼쪽
        }
        else
        {
            anim.CrossFade("Idle", 0.25f);  // 정지 시 Idle
        }
    }
}
