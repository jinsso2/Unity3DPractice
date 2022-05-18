using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 내비게이션 기능을 사용하기 위해 추가해야 하는 네임스페이스
using UnityEngine.AI;
public class MonsterScript : MonoBehaviour
{
    private Transform mosterTr;
    private Transform playerTr;
    private NavMeshAgent agent;

    void Start()
    {
        // 몬스터의 Transfrom 할당
        mosterTr = GetComponent<Transform>();

        // 추적 대상인 Plyaer의 태그를 찾아 Transform 할당
        playerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();

        // NavMeshAgent 컴포넌트 할당
        agent = GetComponent<NavMeshAgent>();

        // 추적 대상의 위치를 설정하면 바로 추적 시작
        agent.destination = playerTr.position;
    }

   
    void Update()
    {
        
    }
}
