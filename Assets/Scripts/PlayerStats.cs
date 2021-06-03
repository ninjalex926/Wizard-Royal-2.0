using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public Health_Bar healthbar;

    public Mana_Bar manabar;

    [SerializeField] private GameManager gameManager;

    public int maxHealth;
        public int currentPlayerHealth;

    public int maxMana;
    public int currentPlayerMana;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.SetHealth(currentPlayerHealth);
        manabar.SetMana(currentPlayerMana);
    }

    public void ManaCost(int manaCost)
    {
        currentPlayerMana -= manaCost;

        manabar.SetMana(currentPlayerMana);

    }

    public void TakeDamage(int damageAmount)
    {
        currentPlayerHealth -= damageAmount;

        healthbar.SetHealth(currentPlayerHealth);

        if (currentPlayerHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        gameManager.LoadLevel("TestScene");
    }
}
