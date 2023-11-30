using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm_instance = null;
    //Headers are userd for viewing property in Unity 헤더로 묶인 변수들 유니티에서 값 수정이 가능해짐
    [Header("# Game Control")]
    public float f_gameTime;
    public float f_maxGameTime; //누가 정해주세요 강좌 10에 있을걸요 -예현
    [Header("# Player Info")]
    public float f_health; //health 플레이어 체력
    public float f_maxHealth = 100; //health 플레이어 최대 체력
    public int i_level; //level 플레이어 레벨
    public int i_kill; //kill 킬 수
    public int i_exp; //exp 경험치
    [Header("# Board Managing")]
    public BoardManager bm_boardScript;
    private int iLevel = 9;

    // Start is called before the first frame update
    void Awake()
    {
        if (gm_instance == null)
            gm_instance = this;
        else if (gm_instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        bm_boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    /*Public void GameStart() //Game start 게임 시작
    {
        f_health = f_maxHealth; //health is set by max when it start 시작할때 체력이 최대체력으로 설정됨
    }*/

    void InitGame()
    {
        bm_boardScript.SetupScene(iLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
