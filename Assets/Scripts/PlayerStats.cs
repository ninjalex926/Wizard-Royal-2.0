using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public Health_Bar healthbar;

    public Mana_Bar manabar;

    public Fire_Manabar fireManabar;

    [SerializeField] private GameManager gameManager;

    public int maxHealth;
    public int currentPlayerHealth;

    public int maxMana;
    public int currentPlayerMana;

    public int maxFireMana;
    public int currentFirePlayerMana;

    public int maxWaterMana;
    public int currentWaterPlayerMana;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.SetHealth(currentPlayerHealth);
        manabar.SetMana(currentPlayerMana);
        fireManabar.SetFireMana(currentFirePlayerMana);
    }

    /// <summary>
    /// Casting a Spell Cost Mana
    /// </summary>
    /// <param name="manaCost"></param>
    public void ManaCost(int manaCost)
    {
        currentPlayerMana -= manaCost;

        manabar.SetMana(currentPlayerMana);

    }

    /// <summary>
    /// Casting a Spell Cost Mana
    /// </summary>
    /// <param name="manaCost"></param>
    public void FireManaCost(int fireManaCost)
    {
        currentFirePlayerMana -= fireManaCost;

        fireManabar.SetFireMana(currentFirePlayerMana);

    }

    /// <summary>
    /// Player taking Damage
    /// </summary>
    /// <param name="damageAmount"></param>
    public void TakeDamage(int damageAmount)
    {
        currentPlayerHealth -= damageAmount;

        healthbar.SetHealth(currentPlayerHealth);

        if (currentPlayerHealth <= 0f)
        {
            Die();
        }
    }

    /// <summary>
    /// Player dying
    /// </summary>
    void Die()
    {
        Destroy(gameObject);
        gameManager.LoadLevel("TestScene");
    }
}
