using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameValues : MonoBehaviour
{

    public static GameValues instance;

    
    public int nbGenes { get; private set; } //utilise ca si tu veux que le setter soit public: {get;set;}
    public int score { get; private set; }
    public List<int> craftedInBestiaire = new();

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
}
