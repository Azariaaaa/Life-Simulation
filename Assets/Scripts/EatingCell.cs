using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingCell : Cell
{
    public override void Initialize(GameObject prefab)
    {
        base.Initialize(prefab);
        cellType = Type.EatingCell;
        spriteRenderer.color = Color.green;
        energyConsumption = 0;
    }
}
