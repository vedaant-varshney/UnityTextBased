using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont
{

    // The player will mainly just have attributes/effects
    // We will need to code a way to have interactions with these effects

    private int health = 5;
    private int attack = 1;
    private int luck = 0;
    private int health_cap = 5;
    private int attack_cap = 1;
    private int luck_cap = 0;

    public void addEffect(int[] eff)
    {
        health += eff[0];
        attack += eff[1];
        luck += eff[2];
        health_cap += eff[3];
        attack_cap += eff[3];
        luck_cap += eff[3];
    }

    public void changeEff(int[] effChange)
    {
        health = effChange[0];
        attack = effChange[1];
        luck = effChange[2];
        health_cap = effChange[3];
        attack_cap = effChange[3];
        luck_cap = effChange[3];
    }


    public int[] getStats()
    {
        return new int[] { health, attack, luck };
    }
    
    // We handle combat when encountering an enemy. Check effects on health and attack
    // The effect array of an enemy has its attack and health stats, the key to combat
    public bool combat(int[] enEff)
    {
        int buff = 0;
        System.Random rnd = new System.Random();
        if (rnd.Next(0, 11) < luck) {
            buff = attack;  
        }

        int enHealth = enEff[0];
        int enAtt = enEff[1];
        while (enHealth > 0)
        {
            health -= enAtt;
            enHealth -= attack + buff;
        }
        
        if (health > 0)
        {
            changeEff(new int[] { health, attack, luck, health_cap, attack_cap, luck_cap });
            return true;
        }
        else
        {
            return false;
        }



    }




}
