using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodUnit : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    public PolygonCollider2D polygonCollider2D;
    public int feedValue;
    public float moveForce;
    public float moveInterval;
    public virtual void Initialize(GameObject prefab)
    {
        rigidBody = prefab.GetComponent<Rigidbody2D>();
        spriteRenderer = prefab.GetComponent<SpriteRenderer>();
        polygonCollider2D = prefab.GetComponent<PolygonCollider2D>();
        feedValue = 50;
        moveForce = 0.8f;
        moveInterval = 0.5f;
    }

    private void Start()
    {
        InvokeRepeating("Move", 0, moveInterval);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Cell cell = collision.gameObject.GetComponent<Cell>();

        if (cell != null) 
        {
            if (cell.cellType == Type.EatingCell)
            {
                cell.organism.energy += feedValue;
                GameStatsManager.Instance.foodEatenValue++;
            }
            if (cell.cellType == Type.AttackingCell || cell.cellType == Type.EatingCell)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Move()
    {
        if(rigidBody != null)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            rigidBody.AddForce(randomDirection * moveForce, ForceMode2D.Impulse);
        }
    }
}
