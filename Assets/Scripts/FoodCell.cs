using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food
{
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    public CircleCollider2D circleCollider;
    public virtual void Initialize(GameObject prefab)
    {
        rigidBody = prefab.GetComponent<Rigidbody2D>();
        spriteRenderer = prefab.GetComponent<SpriteRenderer>();
        circleCollider = prefab.GetComponent<CircleCollider2D>();
    }
}
