using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sightofenemy : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float Speed;
    [SerializeField] private float damage;
    private Animator anim;

    private bool movingLeft;
    private float LeftEdge;
    private float RightEdge;


    private void Awake()
    {
        LeftEdge = transform.position.x - movementDistance;
        RightEdge = transform.position.x + movementDistance;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > LeftEdge)
            {
                transform.position = new Vector3(transform.position.x - Speed * Time.deltaTime, transform.position.y, transform.position.z);
                transform.localScale = new Vector3(2, 1, 1);


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
                transform.localScale = new Vector3(-2, 1, 1);


            }
            else
            {
                movingLeft = true;

            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health3>().TakeDamage(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            movingLeft = false;
            //transform.localScale = new Vector3(-159, 264, 1);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FSG")
        {
            movingLeft = false;
            //transform.localScale = new Vector3(-159, 264, 1);
        }
        else if (collision.gameObject.tag == "FBG")
        {
            movingLeft = false;
            //transform.localScale = new Vector3(-159, 264, 1);
        }
    }
}
