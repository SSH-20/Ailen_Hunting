using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    public GameObject scrollbar;
    public Image stageimage;
    public Text stagename;
    public Image[] images;
    public Text[] texts;
    float scroll_pos = 0;
    float[] pos;
    float distance;

    void Start()
    {
        pos = new float[images.Length];
        distance = 1f / (images.Length - 1f);

        for(int i = 0; i < images.Length; i++)
        {
            pos[i] = distance * i;
        }
    }

    void Update()
    {
        scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
    }

    public void ChangeStage()
    {
        for(int i = 0; i < pos.Length; i++)
        {
            if(scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                stageimage.sprite = images[i].sprite;
                stagename.text = texts[i].text;
            }
        }
    }
}
