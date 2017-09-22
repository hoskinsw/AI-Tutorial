using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayer : MonoBehaviour
{
    // Normal Movements Variables
    private float walkSpeed;
    private float sprintSpeed;
    private float curSpeed;
    private float maxSpeed;

    private Rigidbody2D rigid;

    private CharacterStat plStat;

    void Start()
    {
        plStat = GetComponent<CharacterStat>();
        rigid = GetComponent<Rigidbody2D>();

        walkSpeed = (float)(plStat.speed + (plStat.agility / 5));
        sprintSpeed = walkSpeed + (walkSpeed / 2);

        curSpeed = walkSpeed;
        maxSpeed = walkSpeed;
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
                                       Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));
    }
}