using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] //(직렬화를 통해 유니티 인스펙터에서 값 조정가능)
    private GameObject gObj_Cam;
    private Rigidbody2D rb2D_player;
    private SpriteRenderer spr_player;
    private Animator anim_player;

    // Start is called before the first frame update
    void Start()
    {
        rb2D_player = GetComponent<Rigidbody2D>();
        spr_player = GetComponent<SpriteRenderer>();
        anim_player = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (게임매니저에서 게임이 시작된 상태가 아닐때) return;
        
        gObj_Cam.transform.position = transform.position - new Vector3(0f, 0f, 10f);
    }

    // test move function
    void FixedUpdate()
    {
        //if (게임매니저에서 게임이 시작된 상태가 아닐때) return;

        float horSpeed = Input.GetAxis("Horizontal") * 5;
        float verSpeed = Input.GetAxis("Vertical") * 5;

        rb2D_player.velocity = new Vector2(horSpeed, verSpeed);
    }

    void LateUpdate()
    {
        //if (게임매니저에서 게임이 시작된 상태가 아닐때) return;
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        //if (게임매니저에서 게임이 시작된 상태가 아닐때) return;

        GameManager.gm_instance.f_health -= Time.deltaTime * 10;

        //체력이 다 떨어졌을 때 실행(아직 구현X)
        /*if(GameManager.gm_instance.f_health < 0)
        {
            //transform의 자식 오브젝트들을 가져옴(강좌 13 참고)
            for (int index=2; index < transform.childCount; index++)
            {
                transform.GetChild(index).gameObject.SetActive(false);
            }

            //anim_player.SetTrigger("Dead"); 죽는 애니메이션 실행, 아직없어서 주석처리
        }*/
    }
    
    //참고용이라서 주석처리해둔 코드
    /*colliding logics 충돌 로직
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
            return;
        health -= collision.GetComponent<Enemy>().damage;
        if (health > 0)
        {
            //idle, hit motion
        }
        else
        {
            //died
            Dead();
        }
    }

    void Dead()
    {

    }*/
}
