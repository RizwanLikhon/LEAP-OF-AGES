using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    /*
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
    }*/

    [SerializeField] private Transform target;
    [SerializeField] private float minimumDistance;
    [SerializeField] private float movementDistance;
    [SerializeField] private float Speed;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;


     private bool movingLeft;
    private float LeftEdge;
    private float RightEdge;

    
    private void Awake()
    {
        LeftEdge = transform.position.x - movementDistance;
        RightEdge = transform.position.x + movementDistance;
    }
    private void Update()
    {

        cooldownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {

            }
        }



        if (Vector2.Distance(target.position, target.position) < minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        }
        else
        {

        }


    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range
            , boxCollider.bounds.size, 0, Vector2.left, 0,playerLayer);
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range, boxCollider.bounds.size);
    }
   
    


}


