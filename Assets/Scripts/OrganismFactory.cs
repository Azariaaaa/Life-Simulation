using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OrganismFactory
{
    public static Organism GetRandomOrganism(GameObject organismPrefab, GameObject cellPrefab)
    {
        GameObject newOrganism = Object.Instantiate(organismPrefab, WorldMap.GetNewRandomPostion(), Quaternion.identity);
        Organism organismComponent = newOrganism.GetComponent<Organism>();
        List<Cell> cells = GetListOfRandomCells(cellPrefab);
        AttachCellToOrganism(cells, organismComponent); // nul 
        organismComponent.Initialize(cells);

        return organismComponent;
    }

    private static List<Cell> GetListOfRandomCells(GameObject cellPrefab)
    {
        int randomAmountOfCells = Random.Range(1, 6);
        List<Cell> cells = new List<Cell>();

        for (int i = 0; i < randomAmountOfCells; i++)
        {
            Vector2 randomPosition = WorldMap.GetNewRandomPostion();
            Cell cell = CellFactory.CreateRandomCell(cellPrefab);
            cells.Add(cell);
        }

        return cells;
    }

    private static void AttachCellToOrganism(List<Cell> cells, Organism organism)
    {
        foreach (Cell cell in cells)
        {
            cell.organism = organism;
        }
    }
}
