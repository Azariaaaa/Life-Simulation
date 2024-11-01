using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingCell : Cell
{

    public override void Initialize(GameObject prefab)
    {
        base.Initialize(prefab);
        cellType = Type.AttackingCell;
        spriteRenderer.color = Color.red;
        energyConsumption = 10;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Cell otherCell = collision.gameObject.GetComponent<Cell>();

        if (otherCell != null)
        {
            if (otherCell.organism != organism)
            {
                Attack(otherCell);
                organism.energy -= energyConsumption;
                GameStatsManager.Instance.cellsKilledValue++;
            }
        }
    }

    private void Attack(Cell otherCell)
    {
        if(otherCell.organism != organism)
        {
            otherCell.organism.RemoveCell(otherCell);
        }
    }
}
