using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
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
    public List<Ressource> currentRunInventory = new();
    public List<Combinaison> recettesAnimaux;

    private void Awake()
    {
        if (instance == null)
        {
            
            instance = this;
            createInventory(inventory);
            loadCombinaisons();
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    private void loadCombinaisons()
    {
        recettesAnimaux.Add(new Combinaison("rat","mammifere",new Ressource("Rouge","common",1,true),new Ressource("Triangle","common",1,true),new Ressource("Ligne","common",1,true)));
        recettesAnimaux.Add(new Combinaison("rat","mammifere",new Ressource("Rouge","common",1,true),new Ressource("Triangle","common",1,true),new Ressource("Ligne","common",1,true)));

    }

    public void addItem(string name, int nb, List<Ressource> inventory)
    {
        foreach(Ressource ressource in inventory)
        {
            if (ressource.name == name)
            {
                ressource.number += nb;
            }
        }
    }

    public int getItem(string name, List<Ressource> inventory)
    {
        foreach(Ressource ressource in inventory)
        {
            if (ressource.name == name)
            {
                return ressource.number;
            }
        }

        return 0;
    }
    public void createInventory(List<Ressource> inventory)
    {
        //couleurs
        inventory.Add(new Ressource("Rouge","common",0,true));
        inventory.Add(new Ressource("Orange","common",0,true));
        inventory.Add(new Ressource("Jaune","uncommon",0,true));
        inventory.Add(new Ressource("Vert","uncommon",0,true));
        inventory.Add(new Ressource("Bleu","rare",0,true));
        inventory.Add(new Ressource("Mauve","rare",0,true));
        //formes
        inventory.Add(new Ressource("Triangle","common",0,true));
        inventory.Add(new Ressource("pentagone","common",0,true));
        inventory.Add(new Ressource("Carre","uncommon",0,true));
        inventory.Add(new Ressource("Losange","uncommon",0,true));
        inventory.Add(new Ressource("Hexagone","rare",0,true));
        inventory.Add(new Ressource("Cercle","rare",0,true));
        //motifs
        inventory.Add(new Ressource("Ligne","common",0,true));
        inventory.Add(new Ressource("Carreaute","common",0,true));
        inventory.Add(new Ressource("Pois","common",0,true));
        inventory.Add(new Ressource("Vague","common",0,true));
        
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

    public void encaisserGains()
    {
        foreach (Ressource ressource in currentRunInventory)
        {
            addItem(ressource.name,ressource.number,inventory);
        }
    }

}

public class Ressource
{

    public string name { set; get; }
    public string rarity { set; get; }
    public int number { set; get; }
    public bool gene { set; get; }

    public Ressource(string name, string rarity, int number, bool gene)
    {
        this.name = name;
        this.rarity = rarity;
        this.number = number;
        this.gene = gene;
    }
}
public class Combinaison
{
    public string animal { get; set; }
    public string regneAnimal { get; set; }
    public Ressource requiredColor { get; set; }
    public Ressource requiredShape { get; set; }
    public Ressource requiredMotif { get; set; }
    public Combinaison(string animal, string regneAnimal, Ressource requiredColor, Ressource requiredShape,Ressource requiredMotif)
    {
        this.animal = animal;
        this.regneAnimal = regneAnimal;
        this.requiredColor = requiredColor;
        this.requiredShape = requiredShape;
        this.requiredMotif = requiredMotif;
    }
}

