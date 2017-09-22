using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownEnemy : MonoBehaviour {

    public enum States {Default, Follow};

    public List<Transform> waypoints;
    public States state;
    public int currWayPoint = 0;
    public Transform player;

    private float walkSpeed;
    private float sprintSpeed;
    private float curSpeed;
    private float maxSpeed;

    public float threshold = .05f;

    Rigidbody2D rigid;

    private CharacterStat enStat;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        enStat = GetComponent<CharacterStat>();

        walkSpeed = (float)(enStat.speed + (enStat.agility / 5));
        sprintSpeed = walkSpeed + (walkSpeed / 2);

        curSpeed = walkSpeed;
        maxSpeed = walkSpeed;
    }

    void FixedUpdate () {
        Vector3 moveTo = new Vector2();
        switch (state)
        {
            case States.Default:
                moveTo = waypoints[currWayPoint].position;
                break;
            case States.Follow:
                moveTo = player.position;
                break;
        }
        Vector2 dir = (moveTo - transform.position).normalized;

        rigid.velocity = dir * curSpeed;
        if((waypoints[currWayPoint].position - transform.position).magnitude < threshold)
        {
            currWayPoint++;
            //rigid.velocity = Vector2.zero;
            if(currWayPoint >= waypoints.Count)
            {
                currWayPoint = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name.Equals("player"))
        {
            state = States.Follow;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.name.Equals("player"))
        {
            state = States.Default;
        }
    }
}
