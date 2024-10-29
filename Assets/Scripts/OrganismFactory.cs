using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OrganismFactory
{
    public static Organism CreateRandomOrganism(GameObject organismPrefab, GameObject cellPrefab)
    {
        Vector2 randomPosition = WorldMap.GetNewRandomPostion();
        GameObject newOrganism = UnityEngine.Object.Instantiate(organismPrefab, randomPosition, Quaternion.identity);
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
