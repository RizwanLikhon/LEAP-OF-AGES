using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RizwanAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private float damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask EnemyLayer;
    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;
    private EnemyHealth enemyhealth;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {

        cooldownTimer += Time.deltaTime;
        //Attack only when player in sight?
        if (EnemyInSight())
        {
            anim.SetTrigger("attack");
        }
    }
    private bool EnemyInSight()
    {

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, EnemyLayer);


        if (hit.collider != null)
        {

            enemyhealth = hit.transform.GetComponent<EnemyHealth>();
        }
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
        

    }
    private void DamageEnemy()
    {

        if (EnemyInSight())
        {

            enemyhealth.TakeDamage(damage);
            //moving=false;
        }
        else
        {
            //moving=true;
        }
    }
}
