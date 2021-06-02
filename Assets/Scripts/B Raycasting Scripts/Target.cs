
using UnityEngine;

public class Target : MonoBehaviour
{
    public int targetHp; 

    public int targetMaxHp;

    public Health_Bar targetHealthBar;

    [HideInInspector] public Rigidbody targetRB;


    public void Start()
    {
        targetHp = targetMaxHp;
    }

    public void Update()
    {
   //    
    }


    public void TakeDamage(int damageAmount)
    {
       targetHp -= damageAmount;

        targetHealthBar.SetHealth(targetHp);

        if (targetHp <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
