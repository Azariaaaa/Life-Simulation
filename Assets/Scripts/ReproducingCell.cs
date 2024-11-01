using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproducingCell : Cell
{
    public static event Action OnReproducingCellsCollision;
    public override void Initialize(GameObject prefab)
    {
        base.Initialize(prefab);
        cellType = Type.ReproducingCell;
        spriteRenderer.color = Color.magenta;
        energyConsumption = 40;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Cell otherCell = collision.gameObject.GetComponent<Cell>();

        if (otherCell != null)
        {
            if (otherCell.cellType == Type.ReproducingCell && otherCell.organism != organism && otherCell.organism.cells.Count == organism.cells.Count)
            {
                OnReproducingCellsCollision();
            }
        }
    }
}
