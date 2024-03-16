using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PokemonData : MonoBehaviour
{
    private enum types
    {
        Normal,
        Feu,
        Eau,
        Plante,
        Elektrik,
        Glace,
        Combat,
        Poison,
        Sol,
        Vol,
        Psy,
        Insecte,
        Roche,
        Spectre,
        Dragon,
        Ténèbres,
        Acier,
        Fée,
        None
    }
    [SerializeField] private string name = "Regigigas";
    [SerializeField] private int maxHP = 424;
    private int currentHP = 361;
    [SerializeField] private int attack = 460;
    [SerializeField] private int defense = 350;
    private int stats;
    [SerializeField] private float weight = 420.0f;
    [SerializeField] private types type = types.Normal;
    [SerializeField] private types[] weaknesses = { types.Acier, types.Combat };
    [SerializeField] private types[] resistances = { types.Spectre, types.Insecte };

    private void Awake()
    {
       stats = maxHP + attack + defense;
}
    private void Start()
    {
        InitCurrentLife();
        InitStatsPoints();
        displayName();
        displayType();
        displayMaxHP();
        displayCurrentHP();
        displayAttack();
        displayDefense();
        displayStats();
        displayWeight();
        displayWeaknesses();
        displayResistances();
        TakeDamage(10, types.Acier);
    }
    private void Update()
    {
        CheckIfPokemonAlive();
    }
    void displayName()
    {
        Debug.Log("Le pokémon choisi est : " + name);
    }
    void displayMaxHP()
    {
        Debug.Log(name + " a un total de " + maxHP + " pv.");
    }
    void displayCurrentHP()
    {
        Debug.Log(name + " a actuellement " + currentHP + " pv.");
    }
    void displayAttack()
    {
        Debug.Log(name + " a " + attack + " points d'attaque.");
    }
    void displayDefense()
    {
        Debug.Log(name + " a " + defense + " points de défense.");
    }
    void displayStats()
    {
        Debug.Log(name + " a " + stats + " points de stats.");
    }
    void displayWeight()
    {
        Debug.Log(name + " pèse " + weight + " kg.");
    }
    void displayType()
    {
        Debug.Log(name + " est de type " + type);
    }
    private void displayWeaknesses()
    {
        Debug.Log(name + " est faible face aux types : " + weaknesses);
    }
    private void displayResistances()
    {
        Debug.Log(name + " résiste particulièrement bien aux types : " + resistances);
    }

    private void InitCurrentLife()
    {
        currentHP = maxHP;
    }
    private void InitStatsPoints()
    {
        stats = currentHP + attack + defense;
    }
    private int GetAttackDamage()
    {
        return attack;
    }
    

    
    private void TakeDamage(int opponentDamageDealt, types opponentType)
    {
        if (weaknesses.Contains(opponentType))
        {
            opponentDamageDealt *= 2;
        } else if (resistances.Contains(opponentType))
        {
            opponentDamageDealt /= 2;
        }
        if (opponentDamageDealt> 0) { 
            currentHP -= opponentDamageDealt;
        }
        Debug.Log(currentHP);
    }

    private void CheckIfPokemonAlive()
    {
        if (currentHP > 0)
        {
            Debug.Log(name + " est encore debout ! ");
        }
        else
        {
            Debug.Log(name + " est K.O.");
        }
    }
}
