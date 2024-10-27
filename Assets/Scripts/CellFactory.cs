using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CellFactory
{
    public static Cell CreateRandomCell(GameObject cellPrefab, Vector2 position)
    {
        Cell cellComponent;

        GameObject newCell = GameObject.Instantiate(cellPrefab, position, Quaternion.identity);
        float randomValue = UnityEngine.Random.Range(0,3);

        switch (randomValue)
        {
            case 0:
                cellComponent = newCell.AddComponent<AttackingCell>();
                break;
            case 1:
                cellComponent = newCell.AddComponent<MovingCell>();
                break;
            case 2:
                cellComponent = newCell.AddComponent<EatingCell>();
                break;
            default:
                cellComponent = newCell.AddComponent<MovingCell>();
                break;
        }

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

    public static Cell CreateEatingCell(GameObject cellPrefab, Vector2 position)
    {
        Cell cellComponent;
        GameObject newCell = GameObject.Instantiate(cellPrefab, position, Quaternion.identity);
        cellComponent = newCell.AddComponent<EatingCell>();
        cellComponent.Initialize(newCell);
        return cellComponent;
    }

}
