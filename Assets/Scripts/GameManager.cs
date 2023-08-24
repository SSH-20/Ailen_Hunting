using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm_instance = null;
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

    void InitGame()
    {
        bm_boardScript.SetupScene(iLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
