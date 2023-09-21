using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite spr_dmg;
    public int iHp = 4;

    private SpriteRenderer spriteRenderer;
    // Update is called once per frame
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamageWall(int iLoss)
    {
        spriteRenderer.sprite = spr_dmg;
        iHp -= iLoss;
        if (iHp < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
