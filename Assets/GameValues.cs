using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//public class Ressource;

public class GameValues : MonoBehaviour
{

    public static GameValues instance;
    
    public int score { get; private set; }
    public List<Ressource> inventory = new();
    public List<Ressource> currentRunInventory = new();
    public List<Combinaison> recettesAnimaux = new();

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
        // Basiques (facile)
        recettesAnimaux.Add(new Combinaison("rat","mammifere",new Ressource("Yellow","common",6,true),new Ressource("Triangle","common",3,true),new Ressource("Pois","common",7,true)));
        recettesAnimaux.Add(new Combinaison("canard","oiseau",new Ressource("Yellow","common",7,true),new Ressource("Cercle","common",5,true),new Ressource("Pois","common",8,true)));
        recettesAnimaux.Add(new Combinaison("coccinelle","insecte",new Ressource("Red","common",9,true),new Ressource("Cercle","common",7,true),new Ressource("Pois","common",7,true)));
        recettesAnimaux.Add(new Combinaison("Carpe Koi","poisson",new Ressource("Yellow","common",5,true),new Ressource("Pentagone","uncommon",2,true),new Ressource("Pois","common",10,true)));
        recettesAnimaux.Add(new Combinaison("gecko","reptile",new Ressource("Red","common",7,true),new Ressource("Triangle","common",3,true),new Ressource("Pois","common",8,true)));

        // Évolués (moyen)
        // Mammifères
        recettesAnimaux.Add(new Combinaison("chien","mammifere",new Ressource("Orange","uncommon",5,true),new Ressource("Pentagone","uncommon",4,true),new Ressource("Carreau","uncommon",4,true)));
        recettesAnimaux.Add(new Combinaison("chat","mammifere",new Ressource("Orange","uncommon",3,true),new Ressource("Losange","uncommon",7,true),new Ressource("Carreau","uncommon",10,true)));
        recettesAnimaux.Add(new Combinaison("lapin","mammifere",new Ressource("Purple","uncommon",7,true),new Ressource("Pentagone","uncommon",5,true),new Ressource("Carreau","uncommon",2,true)));
        // Oiseaus
        recettesAnimaux.Add(new Combinaison("corbeau","oiseau",new Ressource("Purple","uncommon",1,true),new Ressource("Losange","uncommon",2,true),new Ressource("Carreau","uncommon",10,true)));
        recettesAnimaux.Add(new Combinaison("pigeon","oiseau",new Ressource("Orange","uncommon",4,true),new Ressource("Losange","uncommon",3,true),new Ressource("Carreau","uncommon",3,true)));
        recettesAnimaux.Add(new Combinaison("cockatiel","oiseau",new Ressource("Purple","uncommon",10,true),new Ressource("Pentagone","uncommon",9,true),new Ressource("Carreau","uncommon",9,true)));
        // Insectes
        recettesAnimaux.Add(new Combinaison("papillon","insecte",new Ressource("Orange","uncommon",6,true),new Ressource("Losange","uncommon",1,true),new Ressource("Carreau","uncommon",8,true)));
        recettesAnimaux.Add(new Combinaison("libellule","insecte",new Ressource("Purple","uncommon",2,true),new Ressource("Losange","uncommon",9,true),new Ressource("Carreau","uncommon",7,true)));
        recettesAnimaux.Add(new Combinaison("abeille","insecte",new Ressource("Orange","uncommon",8,true),new Ressource("Pentagone","uncommon",6,true),new Ressource("Carreau","uncommon",3,true)));
        // Poissons
        recettesAnimaux.Add(new Combinaison("requin","poisson",new Ressource("Orange","uncommon",2,true),new Ressource("Pentagone","uncommon",8,true),new Ressource("Carreau","uncommon",1,true)));
        recettesAnimaux.Add(new Combinaison("poisson-lanterne","poisson",new Ressource("Orange","uncommon",10,true),new Ressource("Losange","uncommon",7,true),new Ressource("Carreau","uncommon",3,true)));
        recettesAnimaux.Add(new Combinaison("Meduse","poisson",new Ressource("Purple","uncommon",6,true),new Ressource("Losange","uncommon",6,true),new Ressource("Carreau","uncommon",9,true)));
        // Reptiles
        recettesAnimaux.Add(new Combinaison("grenouille","reptile",new Ressource("Orange","uncommon",2,true),new Ressource("Losange","uncommon",10,true),new Ressource("Carreau","uncommon",7,true)));
        recettesAnimaux.Add(new Combinaison("tortue","reptile",new Ressource("Purple","uncommon",10,true),new Ressource("Pentagone","uncommon",8,true),new Ressource("Carreau","uncommon",10,true)));
        recettesAnimaux.Add(new Combinaison("serpent","reptile",new Ressource("Purple","uncommon",10,true),new Ressource("Losange","uncommon",6,true),new Ressource("Carreau","uncommon",2,true)));
        
        // Légendaires (difficile)
        recettesAnimaux.Add(new Combinaison("licorne","mammifere",new Ressource("Blue","rare",4,true),new Ressource("Hexagone","rare",5,true),new Ressource("Ligne","rare",2,true)));
        recettesAnimaux.Add(new Combinaison("phoenix","oiseau",new Ressource("Orange","uncommon",8,true),new Ressource("Carre","rare",4,true),new Ressource("Vague","rare",1,true)));
        recettesAnimaux.Add(new Combinaison("luciole","insecte",new Ressource("Yellow","common",10,true),new Ressource("Carre","rare",5,true),new Ressource("Ligne","rare",2,true)));
        recettesAnimaux.Add(new Combinaison("nessy","poisson",new Ressource("Green","rare",3,true),new Ressource("Carre","rare",5,true),new Ressource("Vague","rare",5,true)));
        recettesAnimaux.Add(new Combinaison("dragon","reptile",new Ressource("Green","rare",3,true),new Ressource("Hexagone","rare",5,true),new Ressource("Vague","rare",1,true)));
    }

    public void combinaisonCrafted(string name)
    {
        foreach (Combinaison combinaison in recettesAnimaux)
        {
            if (name == combinaison.animal)
            {
                combinaison.timesCrafted++;
            }
        }
        
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
    public void removeItem(string name, int nb, List<Ressource> inventory)
    {
        foreach(Ressource ressource in inventory)
        {
            if (ressource.name == name)
            {
                ressource.number -= nb;
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
        inventory.Add(new Ressource("Red","common",0,true));
        inventory.Add(new Ressource("Orange","common",0,true));
        inventory.Add(new Ressource("Yellow","uncommon",0,true));
        inventory.Add(new Ressource("Green","uncommon",0,true));
        inventory.Add(new Ressource("Blue","rare",0,true));
        inventory.Add(new Ressource("Purple","rare",0,true));
        //formes
        inventory.Add(new Ressource("Triangle","common",0,true));
        inventory.Add(new Ressource("Pentagone","common",0,true));
        inventory.Add(new Ressource("Carre","uncommon",0,true));
        inventory.Add(new Ressource("Losange","uncommon",0,true));
        inventory.Add(new Ressource("Hexagone","rare",0,true));
        inventory.Add(new Ressource("Cercle","rare",0,true));
        //motifs
        inventory.Add(new Ressource("Ligne","common",0,true));
        inventory.Add(new Ressource("Carreau","common",0,true));
        inventory.Add(new Ressource("Pois","common",0,true));
        inventory.Add(new Ressource("Vague","common",0,true));
        
    }

    

    public void calculScore()
    {
        if (score == 0)
        {
            foreach (Combinaison combinaison in recettesAnimaux)
            {
                if (combinaison.timesCrafted != 0)
                {
                    score += combinaison.timesCrafted * 5;
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
    public int timesCrafted { get; set; }
    public Combinaison(string animal, string regneAnimal, Ressource requiredColor, Ressource requiredShape,Ressource requiredMotif)
    {
        this.animal = animal;
        this.regneAnimal = regneAnimal;
        this.requiredColor = requiredColor;
        this.requiredShape = requiredShape;
        this.requiredMotif = requiredMotif;
        timesCrafted = 0;
    }
}

