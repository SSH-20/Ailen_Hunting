using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject gObj_Cam;
    private Rigidbody2D rb2D_player;

    // Start is called before the first frame update
    void Start()
    {
        rb2D_player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gObj_Cam.transform.position = transform.position - new Vector3(0f, 0f, 10f);
    }

    // test move function
    void FixedUpdate()
    {
        float f_horSpeed = Input.GetAxis("Horizontal") * 5;
        float f_verSpeed = Input.GetAxis("Vertical") * 5;

        rb2D_player.velocity = new Vector2(f_horSpeed, f_verSpeed);
    }
}
