using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    [SerializeField]
    private GameObject gObj_Player;   // Rigidbody2D 객체를 달고있는 플레이어
    private Rigidbody2D rb2D_Player;
    private RectTransform rtf_JoyStick;

    private Vector3 vec3_init;
    private Vector3 vec3_velo;

    private JoystickUtil util;

    [SerializeField, Range(0.1f, 1f)]
    private float f_SpeedFactor;

    // Start is called before the first frame update
    void Start()
    {
        rb2D_Player = gObj_Player.GetComponent<Rigidbody2D>();
        rtf_JoyStick = GetComponent<RectTransform>();
        vec3_init = rtf_JoyStick.position;

        util = new JoystickUtil();
    }

    // Update is called once per frame
    void Update()
    {
        rtf_JoyStick.position = new Vector3(util.f_x, util.f_y, util.f_z);
        vec3_velo = rtf_JoyStick.position - vec3_init;
        rb2D_Player.position += new Vector2(vec3_velo.x, vec3_velo.y)*Time.deltaTime*f_SpeedFactor;

        this.JoystickControl();
    }

    // 조이스틱 조정 부분
    public void JoystickControl()
    {
        if(Input.GetMouseButton(0))
        {
            float x1 = vec3_init.x;
            float y1 = vec3_init.y;
            float x2 = Input.mousePosition.x;
            float y2 = Input.mousePosition.y;
            util.LimitPosition(new Vector2(x1, y1), new Vector2(x2, y2));
        }

        else
        {
            util.ResetPosition();
        }
    }
}
