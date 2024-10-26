using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CellFactory
{
    public static Cell CreateRandomCell(GameObject cellPrefab, Vector2 position)
    {
        Cell cellComponent;

        GameObject newCell = GameObject.Instantiate(cellPrefab, position, Quaternion.identity);
        float randomValue = UnityEngine.Random.value;

        if (randomValue > 0.5f) 
            cellComponent = newCell.AddComponent<AttackingCell>();
        else
            cellComponent = newCell.AddComponent<MovingCell>();

        cellComponent.Initialize(newCell);
        return cellComponent;
    }

    public static Cell CreateMovingCell(GameObject cellPrefab, Vector2 position)
    {
        Cell cellComponent;
        GameObject newCell = GameObject.Instantiate(cellPrefab, position, Quaternion.identity);
        cellComponent = newCell.AddComponent<MovingCell>();
        cellComponent.Initialize(newCell);
        return cellComponent;
    }

    public static Cell CreateAttackingCell(GameObject cellPrefab, Vector2 position)
    {
        Cell cellComponent;
        GameObject newCell = GameObject.Instantiate(cellPrefab, position, Quaternion.identity);
        cellComponent = newCell.AddComponent<AttackingCell>();
        cellComponent.Initialize(newCell);
        return cellComponent;
    }
}
