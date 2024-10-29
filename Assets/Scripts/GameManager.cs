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
        InvokeRepeating("GenerateFood", 0, foodSpawnDelay);

        for (int i = 0; i < organismAmount; i++)
        {
            Vector2 randomPosition = WorldMap.GetNewRandomPostion();
            GameObject newOrganism = Instantiate(organismPrefab, randomPosition, Quaternion.identity);
            Organism organismComponent = newOrganism.GetComponent<Organism>();
            List<Cell> cells = GetListOfRandomCells();
            AttachCellToOrganism(cells, organismComponent); // nul 
            organismComponent.Initialize(cells);
            OnOrganismInitilized(organismComponent);
        }
    }

    private List<Cell> GetListOfRandomCells()
    {
        int randomAmountOfCells = UnityEngine.Random.Range(1,6);
        List<Cell> cells = new List<Cell>();

        for (int i = 0;i < randomAmountOfCells; i++)
        {
            Vector2 randomPosition = WorldMap.GetNewRandomPostion();
            Cell cell = CellFactory.CreateRandomCell(cellPrefab);
            cells.Add(cell);
        }

        return cells;
    }

    private void AttachCellToOrganism(List<Cell> cells, Organism organism)
    {
        foreach (Cell cell in cells)
        {
            cell.organism = organism;
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
}
