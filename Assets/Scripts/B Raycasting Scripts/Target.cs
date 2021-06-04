
using UnityEngine;

public class Target : MonoBehaviour
{
    public int targetHp; 

    public int targetMaxHp;

    public Health_Bar targetHealthBar;

    public bool hideHealthBar;

    public bool isDead;

    public GameObject healthBarObj;

    [HideInInspector] public Rigidbody targetRB;

    public void Start()
    {
        targetHp = targetMaxHp;
    }

    public void Update()
    {
        if (hideHealthBar)
        {
            healthBarObj.SetActive(false);
        }
        else
        {
            healthBarObj.SetActive(true);
        }
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
        if (!isDead)
        {
            Destroy(gameObject);
            isDead = true;
        }

    }
}
