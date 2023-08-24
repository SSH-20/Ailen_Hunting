using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    private GameObject gObj_Player; // player to move with joystick, has Rigidbody2D
    private Rigidbody2D rb2D_Player;
    private RectTransform rtf_JoyStick;
    private Vector3 vec3_init;
    private Vector3 vec3_velo;

    private bool bIsJoystickHeld;

    [Range(0.1f, 1f)]
    public float f_SpeedFactor;

    // Start is called before the first frame update
    void Start()
    {
        rb2D_Player = gObj_Player.GetComponent<Rigidbody2D>();
        rtf_JoyStick = GetComponent<RectTransform>();
        vec3_init = rtf_JoyStick.position;

        bIsJoystickHeld = false;
    }

    // Update is called once per frame
    void Update()
    {
        vec3_velo = rtf_JoyStick.position - vec3_init;
        rb2D_Player.position += new Vector2(vec3_velo.x, vec3_velo.y)*Time.deltaTime*f_SpeedFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        bIsJoystickHeld = true;
        Debug.Log("Joystick Held");
        Debug.Log(eventData.position);

        rtf_JoyStick.position = new Vector3(eventData.position.x, eventData.position.y, 0f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(bIsJoystickHeld)
        {
            rtf_JoyStick.position = new Vector3(eventData.position.x, eventData.position.y, 0f);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Joystick Released");
        rtf_JoyStick.position = vec3_init;
        bIsJoystickHeld = false;
    }
}
