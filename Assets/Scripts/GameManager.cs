using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cellPrefab;
    public GameObject organismPrefab;
    public List<Organism> organisms = new List<Organism>();
    public int organismAmount; 
    private float minXSpawnArea = -9f, maxXSpawnArea = 9f, minYSpawnArea = 3.5f, maxYSpawnArea = -3.5f;

    public static event Action<Organism> OnOrganismInitilized;

    void Start()
    {
        for (int i = 0; i < organismAmount; i++)
        {
            Vector2 randomPosition = new Vector2(UnityEngine.Random.Range(minXSpawnArea, maxXSpawnArea), UnityEngine.Random.Range(minYSpawnArea, maxYSpawnArea));
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
            float randomX = UnityEngine.Random.Range(minXSpawnArea, maxXSpawnArea);
            float randomY = UnityEngine.Random.Range(minYSpawnArea, maxYSpawnArea);
            Vector2 randomPosition = new Vector2(randomX,randomY);
            Cell cell = CellFactory.CreateRandomCell(cellPrefab, randomPosition);
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
}
