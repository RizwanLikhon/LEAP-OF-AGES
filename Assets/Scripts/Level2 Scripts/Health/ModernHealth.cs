using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModernHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
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
        currentHealth = Mathf.Clamp(currentHealth -_mdamage,0,startingHealth);

        if (currentHealth > 0)
        {
            ani.SetTrigger("hurt");
        }
        else
        {
            if(!dead)
            {
                ani.SetTrigger("die");
                //GetComponent<PlayerMovement>().enabled= false;
                dead=true;
            }
        }
    }
}
