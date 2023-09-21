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
        Vector3 pos = gObj_Player.transform.position;
        string tmp = $"X: {pos.x:0}, Y: {pos.y:0}";
        txt_pos.SetText(tmp);
    }
}
