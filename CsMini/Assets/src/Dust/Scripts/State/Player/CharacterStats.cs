using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected int health;

    protected bool isDead;
    protected string namePlayer;


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

    public virtual void die()
    {

        isDead = true;
    }

    public bool isDie()
    {
        return isDead;
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

    public void setPlayerName(string name)
    {
        namePlayer = name;
    }

    public string getPlayerName()
    {
        return namePlayer;
    }

    public void initVariable()
    {
        maxHealth = 100;
        setHealthTo(maxHealth);
        isDead = false;
    }
}
