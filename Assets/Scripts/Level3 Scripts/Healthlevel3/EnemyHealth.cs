using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private BoxCollider2D bc;
    public float currentHealth { get; private set; }
    private Animator ani;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        ani = GetComponent<Animator>();
    }
    
    public void TakeDamage(float _mdamage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _mdamage, 0, startingHealth);

        if (currentHealth > 0)
        {
            ani.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                ani.SetTrigger("die");
                GetComponent<meleEnemy>().enabled = false;
                GetComponent<EnemyFollow>().enabled = false;
                GetComponent<EnemyPatrol>().enabled = false;
                
                dead = true;
            }
        }
    }
    
}
