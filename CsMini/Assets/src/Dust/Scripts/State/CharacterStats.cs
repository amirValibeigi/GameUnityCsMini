using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;

    [SerializeField] protected bool isDead;


    private void Start()
    {
        initVariable();
    }


    public virtual void checkHealth()
    {
        if (health <= 0)
        {
            health = 0;
            die();
        }

        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public void die()
    {

        isDead = true;
    }


    private void setHealthTo(int healthToSetTo)
    {
        health = healthToSetTo;
        checkHealth();
    }

    public void takeDamage(int damage)
    {
        int healthAfterDamage = health - damage;
        setHealthTo(healthAfterDamage);
    }

    public void heal(int heal)
    {
        int healthAfterHeal = health + heal;
        setHealthTo(healthAfterHeal);
    }

    public void initVariable()
    {
        maxHealth = 100;
        setHealthTo(maxHealth);
        isDead = false;
    }
}
