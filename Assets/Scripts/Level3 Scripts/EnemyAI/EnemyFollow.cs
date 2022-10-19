using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFollow : MonoBehaviour
{

    
    
    [SerializeField] private float speed;
    [SerializeField] private float stoppingdistance;
    [SerializeField] private Transform target;
    //private Rigidbody2D body;
    //private meleEnemy mel;
    private Animator anim;


    
    
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        //body = GetComponent<Rigidbody2D>();


    }
    
    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }
    
    void Update()
    {

        if (Vector2.Distance(transform.position, target.position) > stoppingdistance)
        {
            transform.position =  Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            //anim.SetBool("moving", true);
        }
        anim.SetBool("moving", true);


        //anim.SetBool("moving", true);


    }
}
