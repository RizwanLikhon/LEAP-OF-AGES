using UnityEngine;
using UnityEngine.UI;

public class Health3 : MonoBehaviour
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
                GetComponent<RizwanLikhonMovement>().enabled= false;
                dead = true;
            }
        }
    }
}
