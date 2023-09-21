using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float fSpeed;
    public float fHealth;
    public float fMaxHealth;
    public RuntimeAnimatorController[] animCon; 
    public Rigidbody2D target; //몬스터가 쫓아갈 목표 물리
    public GameObject gObj_player; // 몬스터가 쫓아갈 게임오브젝트

    bool bIsLive;//

    Rigidbody2D rigid;
    Collider2D coll;
    Animator anim;
    SpriteRenderer spriter;
    WaitForFixedUpdate wait; //딜레이를 변수로 만들면 부하가 덜함

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
        wait = new WaitForFixedUpdate();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!bIsLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))//살아있지않거나 공격받는 애니메이션일 경우
            return;

        Vector2 v2_dirVec = target.position - rigid.position;  //타겟 위치 - 현재 위치
        Vector2 v2_nextVec = v2_dirVec.normalized * fSpeed * Time.fixedDeltaTime; //프레임에 따라 차이나지 않도록 함
        rigid.MovePosition(rigid.position + v2_nextVec); //현재위치+다음에 가야 할 위치
        rigid.velocity = Vector2.zero; // 물리속도가 이동에 영향받지 않도록 0을 넣어줌
    }
    void LateUpdate()
    {
        if (!bIsLive) //살아있지 않다면
            return; //되돌리고 그게 아니라면

        spriter.flipX = target.position.x < rigid.position.x; //이미지 방향 반전
    }
    void OnEnable()//스크립트가 활성화될 때 실행하는 함수
    {
        target = gObj_player.GetComponent<Rigidbody2D>(); //타겟 지정
        bIsLive = true; //활성화 될 때 라이브가 트루 됨

        coll.enabled = true;
        rigid.simulated = true;
        spriter.sortingOrder = 2; //다시 레이어 순서 원래대로
        anim.SetBool("Dead", false);
        fHealth = fMaxHealth; //체력 초기화
    }

    /*
    public void Init(SpawnData data) //몬스터가 젠 될 스크립트와 연결될 예정
    {
        anim.runtimeAnimatorController = animCon[data.spriteType]; //이미지
        fspeed = data.speed; //속도
        fmaxHealth = data.health; //최대체력
        fhealth = data.health; //체력
    }*/

    void OnTriggerEnter2D(Collider2D collision)// 공격무기에 충돌했을 때
    {
        if (!collision.CompareTag("Bullet") || !bIsLive) // 무기가 아니거나 살아있을때 (사망에 중첩실행 방지)
            return;//

       // fhealth -= collision.GetComponent<Bullet>().damage;// 체력을 플레이어 공격 스크립트와 연결할 예정
        StartCoroutine(KnockBack()); // 피격 코루틴 활성화

        if (fHealth > 0)//
        {
            anim.SetTrigger("Hit");//
        }
        else//
        {
            bIsLive = false;//사망
            coll.enabled = false;//충돌 해제
            rigid.simulated = false;//물리 해제
            spriter.sortingOrder = 1; //스프라이터 순서 변경
            anim.SetBool("Dead", true);//사망 애니메이션 활성
        }
    }
    IEnumerator KnockBack()// 피격시 타격감 코루틴
    {
        yield return wait; //다음 하나의 물리프레임까지 딜레이. null으로 붙이면 물리 1프레임 쉬기. 
                           // yield return new WaitForSeconds(2f); //2초 쉬기 -> 부하가 많이 걸리는 단점
        Vector3 V2_playerPos = gObj_player.transform.position;
        Vector3 V2_dirVec = transform.position - V2_playerPos;
        rigid.AddForce(V2_dirVec.normalized * 3, ForceMode2D.Impulse);
    }
    void Dead()// 사망 시
    {
        gameObject.SetActive(false);
    }
}
