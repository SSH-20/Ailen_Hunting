using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosDebug : MonoBehaviour
{
    private TMPro.TMP_Text txt_pos;
    [SerializeField]
    private GameObject gObj_Player;

    // Start is called before the first frame update
    void Start()
    {
        txt_pos = GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec3_temp = gObj_Player.transform.position;
        string str_temp = $"X: {vec3_temp.x:0}, Y: {vec3_temp.y:0}";
        txt_pos.SetText(str_temp);
    }
}
