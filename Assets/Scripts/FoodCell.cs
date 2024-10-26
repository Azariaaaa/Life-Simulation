using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food
{
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    public PolygonCollider2D polygonCollider2D;
    public int feedValue;
    public virtual void Initialize(GameObject prefab)
    {
        rigidBody = prefab.GetComponent<Rigidbody2D>();
        spriteRenderer = prefab.GetComponent<SpriteRenderer>();
        polygonCollider2D = prefab.GetComponent<PolygonCollider2D>();
        feedValue = 50;
    }
}
