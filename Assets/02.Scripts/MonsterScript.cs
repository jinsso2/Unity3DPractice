using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������̼� ����� ����ϱ� ���� �߰��ؾ� �ϴ� ���ӽ����̽�
using UnityEngine.AI;
public class MonsterScript : MonoBehaviour
{
    private Transform mosterTr;
    private Transform playerTr;
    private NavMeshAgent agent;

    void Start()
    {
        // ������ Transfrom �Ҵ�
        mosterTr = GetComponent<Transform>();

        // ���� ����� Plyaer�� �±׸� ã�� Transform �Ҵ�
        playerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();

        // NavMeshAgent ������Ʈ �Ҵ�
        agent = GetComponent<NavMeshAgent>();

        // ���� ����� ��ġ�� �����ϸ� �ٷ� ���� ����
        agent.destination = playerTr.position;
    }

   
    void Update()
    {
        
    }
}
