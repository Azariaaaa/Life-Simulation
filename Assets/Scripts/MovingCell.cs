using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MovingCell : Cell
{
    public float moveForce;
    public float moveInterval;
    public float timer;

    public override void Initialize(GameObject prefab)
    {
        base.Initialize(prefab);
        cellType = Type.MovingCell;
        spriteRenderer.color = Color.white;
        moveForce = Random.Range(0.5f,2f);
        moveInterval = Random.Range(2f,5f);
        energyConsumption = 20;
    }

    private void Start()
    {
        InvokeRepeating("Move", 0, moveInterval);
    }

    private void Move()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rigidBody.AddForce(randomDirection * moveForce, ForceMode2D.Impulse);
    }
}