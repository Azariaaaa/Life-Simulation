using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cellPrefab;
    public GameObject organismPrefab;
    public GameObject foodPrefab;
    public List<Organism> organisms = new List<Organism>();
    public List<FoodUnit> foodUnits = new List<FoodUnit>(); 
    public int organismAmount;
    public float foodSpawnDelay;
    
    public static event Action<Organism> OnOrganismInitilized;

    void Start()
    {
        ReproducingCell.OnReproducingCellsCollision += GenerateInheritedOrganism; 

        InvokeRepeating("GenerateFood", 0, foodSpawnDelay);

        for (int i = 0; i < organismAmount; i++)
        {
            OnOrganismInitilized(OrganismFactory.GetRandomOrganism(organismPrefab, cellPrefab));
            GameStatsManager.Instance.organismsAliveValue ++;
        }
    }

    private FoodUnit GenerateFood()
    {
        Vector2 randomPosition = WorldMap.GetNewRandomPostion();
        GameObject foodGO = Instantiate(foodPrefab, randomPosition, Quaternion.identity);
        FoodUnit foodUnit = foodGO.AddComponent<FoodUnit>();
        foodUnit.Initialize(foodGO);
        foodUnits.Add(foodUnit);

        return foodUnit;
    }

    private void GenerateInheritedOrganism()
    {
        int AmountOfBabies = UnityEngine.Random.Range(1, 3);

        for (int i = 0;i < AmountOfBabies; i++)
        {
            OnOrganismInitilized(OrganismFactory.GetRandomOrganism(organismPrefab, cellPrefab)); // A modifier ici voir ScriptableObject
            GameStatsManager.Instance.organismsAliveValue++;
            GameStatsManager.Instance.organismsBornValue++;
        }
    }
}
