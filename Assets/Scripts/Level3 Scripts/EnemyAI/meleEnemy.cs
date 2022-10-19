using UnityEngine;

public class meleEnemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float rangeofsight;
    [SerializeField] private float colliderDistance;
    [SerializeField] private float colliderDistanceforsight;
    [SerializeField] private float damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    //private bool moving;
    
    private float cooldownTimer=Mathf.Infinity;

    private Health3 playerHealth;
    private EnemyPatrol enemypatrol;
    private EnemyFollow enemyf;
    //private bool followT;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemypatrol=GetComponent<EnemyPatrol>();
        enemyf=GetComponent<EnemyFollow>(); 
    }
    private void Update()
    {
        enemypatrol.enabled = true;
        cooldownTimer+=Time.deltaTime;
        //Attack only when player in sight?
        if (PlayerInSight())
        {
           
            
            
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer=0;
                anim.SetTrigger("attack");
            }


        }  
        if (enemypatrol != null)
        {
            enemypatrol.enabled = !PlayerInSight();
        }
        if(PlayerInsightAttack())
        {
           enemyf.enabled = true;
            enemypatrol.enabled=false;
        }
        
        if(enemyf != null)
        {
            enemyf.enabled = !enemypatrol.enabled;
            //enemypatrol.enabled = false;
            enemyf.enabled = !PlayerInSight();
        }
        
        
        

    }

    private bool PlayerInsightAttack()
    {
        RaycastHit2D hit2 = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * rangeofsight * transform.localScale.x * colliderDistanceforsight, new Vector3(boxCollider.bounds.size.x * rangeofsight, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        if(hit2.collider != null)
        {
            
        }
        return hit2.collider!=null;
    }


    private bool PlayerInSight()
    {
        
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center+transform.right*range*transform.localScale.x*colliderDistance,new Vector3(boxCollider.bounds.size.x*range,boxCollider.bounds.size.y,boxCollider.bounds.size.z),0,Vector2.left,0,playerLayer);
        

        if(hit.collider !=null)
        {

            playerHealth = hit.transform.GetComponent<Health3>();
        }
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x*colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
        Gizmos.color= Color.blue;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * rangeofsight * transform.localScale.x * colliderDistanceforsight, new Vector3(boxCollider.bounds.size.x * rangeofsight, boxCollider.bounds.size.y, boxCollider.bounds.size.z));


    }

    private void DamagePlayer()
    {

        if (PlayerInSight())
        {

            playerHealth.TakeDamage(damage);
            //moving=false;
        }
        else
        {
            //moving=true;
        }
    }
}
