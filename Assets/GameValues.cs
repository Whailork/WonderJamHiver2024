using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//public class Ressource;

public class GameValues : MonoBehaviour
{

    public static GameValues instance;

    
    public int nbGenes { get; private set; } //utilise ca si tu veux que le setter soit public: {get;set;}
    public int score { get; private set; }
    public List<int> craftedInBestiaire = new();
    public List<Ressource> inventory = new();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void incrementNbGenes(int value)
    {
        Debug.Log("+1 gene");
        nbGenes += value;
    }

    public void calculScore()
    {
        if (score == 0)
        {
            foreach (int nb in craftedInBestiaire)
            {
                if (nb != 0)
                {
                    score += nb * 5;
                }
            
            }
        }
        
    }

    public void updateScore(int spliceValue)
    {
        score += spliceValue * 5;
    }

    public void addRessource(Ressource item)
    {
        inventory.Add(item);
    }

    public void addQuantity(string name, int quantity)
    {
        foreach (Ressource item in inventory.ToArray())
        {
            if (item.name == name) {
                //item.number += quantity;
                item.number = item.number + quantity;
                break;
            }
        }
    }
}

public class Ressource
{

    public string name { set; get; }
    public string rarity { set; get; }
    public int number { set; get; }

    public Ressource(string name, string rarity, int number)
    {
        this.name = name;
        this.rarity = rarity;
        this.number = number;
    }
}
