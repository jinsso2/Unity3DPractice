using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������̼� ����� ����ϱ� ���� �߰��ؾ� �ϴ� ���ӽ����̽�
using UnityEngine.AI;
public class MonsterScript : MonoBehaviour
{
    public enum State
    {
        IDLE,
        PATROL,
        TRACE,
        ATTACK,
        DIE
    }

    // ������ ���� ����
    public State state = State.IDLE;
    // ���� �����Ÿ�
    public float traceDist = 10.0f;
    // ���� �����Ÿ�
    public float attactDist = 2.0f;
    // ������ ��� ����
    public bool isDie = false;

    private Transform monsterTr;
    private Transform playerTr;
    private NavMeshAgent agent;
    private Animator anim;

    void Start()
    {
        // ������ Transfrom �Ҵ�
        monsterTr = GetComponent<Transform>();

        // ���� ����� Plyaer�� �±׸� ã�� Transform �Ҵ�
        playerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();

        // NavMeshAgent ������Ʈ �Ҵ�
        agent = GetComponent<NavMeshAgent>();

        // Animator ������Ʈ �Ҵ�
        anim = GetComponent<Animator>();

        // ���� ����� ��ġ�� �����ϸ� �ٷ� ���� ����
        // agent.destination = playerTr.position;

        // ������ ���¸� üũ�ϴ� �ڷ�ƾ �Լ� ȣ��
        StartCoroutine(CheckMonsterState());
        // ���¿� ���� ������ �ൿ�� �����ϴ� �ڷ�ƾ �Լ� ȣ��
        StartCoroutine(MonsterAction());
    }

    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            // 0.3�ʵ��� ����(���) �ϴ� ���� ������� �޽��� ������ �纸
            yield return new WaitForSeconds(0.3f);

            // ���Ϳ� ���ΰ� ĳ���� ������ �Ÿ� ����
            float distance = Vector3.Distance(playerTr.position, monsterTr.position);

            //���� �����Ÿ� ������ ���Դ��� Ȯ��
            if(distance <= attactDist)
            {
                state = State.ATTACK;
            }
            // ���� �����Ÿ� ������ ���Դ��� Ȯ��
            else if(distance <= traceDist)
            {
                state = State.TRACE;
            }
            else
            {
                state = State.IDLE;
            }
        }
    }
    
    IEnumerator MonsterAction()
    {
        while(!isDie){
            switch (state)
            {
                // IDLE ����
                case State.IDLE:
                    // ���� ����
                    agent.isStopped = true;
                    // Animator�� IsTrace ������ false�� ����
                    anim.SetBool("IsTrace", false);
                    break;

                // ���� ����
                case State.TRACE:
                    // ���� ����� ��ǥ�� �̵� ����
                    agent.SetDestination(playerTr.position);
                    agent.isStopped = false;
                    // Animator�� IsTrace ������ true�� ����
                    anim.SetBool("IsTrace", true);
                    break;

                // ���� ����
                case State.ATTACK:
                    break;

                // ���
                case State.DIE:
                    break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    void OnDrawGizmos()
    {
        // ���� �����Ÿ� ǥ��
        if(state == State.TRACE)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, traceDist);
        }
        // ���� �����Ÿ� ǥ��
        if(state == State.ATTACK)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attactDist);
        }
    }
}
