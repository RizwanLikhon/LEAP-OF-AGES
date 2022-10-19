using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float Speed;
    [SerializeField] private float idleDuration;

    private float idleTimer;
    private Animator anim;
    private Rigidbody2D body;

    private bool movingLeft;
    private float LeftEdge;
    private float RightEdge;
    private bool grounded;


    private void Awake()
    {
        LeftEdge = transform.position.x - movementDistance;
        RightEdge = transform.position.x + movementDistance;
        anim = GetComponent<Animator>();
    }
    
    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }
    private void Update()
    {
        idleTimer = 0;
        anim.SetBool("moving",true);
        if (movingLeft)
        {
            if (transform.position.x > LeftEdge)
            {
                transform.position = new Vector3(transform.position.x - Speed * Time.deltaTime, transform.position.y, transform.position.z);
                transform.localScale = new Vector3(-51, 78, 1);


            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < RightEdge)
            {
                transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime, transform.position.y, transform.position.z);
                transform.localScale = new Vector3(51, 78, 1);


            }
            else
            {
                movingLeft = true;

            }

        }
        /*
        if (grounded)
        {
            Jump();
        }
        anim.SetBool("grounded", grounded);*/
    }
    private void DirectionChange()
    {
        //anim.SetBool("moving", false);
        idleTimer = Time.deltaTime;
        if(idleTimer>idleDuration)
        {
            movingLeft = !movingLeft;

        }
         
    }
    /*
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, body.velocity.y);
        anim.SetTrigger("jump");
        grounded = false;

    }*/
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;

        }
        if(collision.gameObject.tag == "BFG")
        {
            grounded = true;
        }
        if((collision.gameObject.tag == "Player")&& !grounded)
        {
            //Jump();
        }

        if(collision.gameObject.tag=="Wall")
        {
            movingLeft=true;
        }
    }
}
