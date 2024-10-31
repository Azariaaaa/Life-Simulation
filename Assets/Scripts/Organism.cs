using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Organism : MonoBehaviour
{
    public GameObject organismGameObject;
    public List<Cell> cells = new List<Cell>();
    public int energy = 50;
    public bool isAlive => energy > 0;
    public static event Action<Organism> OnOrganismRemoved;

    public void Initialize(List<Cell> cells)
    {
        organismGameObject = gameObject;
        this.cells = cells;
        ArrangeCellsInCircle();
        ConnectCells();
        //ColorizeCells();
    }

    void Start()
    {
        InvokeRepeating("EnergyConsumption", 10, 10);
    }

    private void Update()
    {
        if (isAlive)
        {
            foreach (Cell cell in cells)
            {
                LineRenderer lineRenderer = cell.GetComponent<LineRenderer>();

                if (lineRenderer != null)
                {
                    lineRenderer.SetPosition(0, organismGameObject.transform.position);
                    lineRenderer.SetPosition(1, cell.transform.position);
                }
            }
        }
        else
        {
            RemoveOrganism();
        }
        
    }

    public void RemoveOrganism()
    {
        for (int i = cells.Count - 1; i >= 0; i--)
        {
            RemoveCell(cells[i]);
        }

        OnOrganismRemoved?.Invoke(this);
        Destroy(gameObject);
    }

    public void RemoveCell(Cell cell)
    {
        cells.Remove(cell);
        Destroy(cell.gameObject);
    }

    public void EnergyConsumption()
    {
        foreach (Cell cell in cells)
        {
            energy -= cell.energyConsumption;
        }
    }
    public void ArrangeCellsInCircle()
    {
        
        float angleStep = 360f / cells.Count;
        float radius = 0.5f;
        Vector3 organismPosition = organismGameObject.transform.position;

        for (int i = 0; i < cells.Count; i++)
        {
            float angleInRadians = Mathf.Deg2Rad * (i * angleStep);
            float x = organismPosition.x + Mathf.Cos(angleInRadians) * radius;
            float y = organismPosition.y + Mathf.Sin(angleInRadians) * radius;
            cells[i].transform.position = new Vector3(x, y, organismPosition.z);
        }
    }
    public void ConnectCells()
    {
        foreach(Cell cell in cells)
        {
            DistanceJoint2D joint = cell.gameObject.AddComponent<DistanceJoint2D>();
            joint.connectedBody = organismGameObject.GetComponent<Rigidbody2D>();
            joint.autoConfigureDistance = false;
            joint.distance = Vector2.Distance(cell.transform.position, organismGameObject.transform.position);
            joint.maxDistanceOnly = true;
            joint.breakForce = Mathf.Infinity;

            if(cells.Count > 1)
            {
                LineRenderer lineRenderer = cell.gameObject.AddComponent<LineRenderer>();
                lineRenderer.positionCount = 2;
                lineRenderer.startWidth = 0.025f;
                lineRenderer.endWidth = 0.025f;
                lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                lineRenderer.startColor = Color.white;
                lineRenderer.endColor = Color.white;
            }
        }
        //test git

        //public void AddCell(Cell cell)
        //{
        //    cells.Add(cell);
        //}

        //private void ColorizeCells()
        //{
        //    int randomInt = UnityEngine.Random.Range(0, 9);
        //    Color color = Color.clear;

        //    switch (randomInt)
        //    {
        //        case 0:
        //            color = Color.white;
        //            break;
        //        case 1:
        //            color = Color.blue;
        //            break;
        //        case 2:
        //            color = Color.cyan;
        //            break;
        //        case 3:
        //            color = Color.green;
        //            break;
        //        case 4:
        //            color = Color.red;
        //            break;
        //        case 5:
        //            color = Color.yellow;
        //            break;
        //        case 6:
        //            color = Color.black;
        //            break;
        //        case 7:
        //            color = Color.grey;
        //            break;
        //        case 8:
        //            color = Color.magenta;
        //            break;
        //    }

        //    foreach (Cell cell in cells)
        //    {
        //        cell.spriteRenderer.color = color; 
        //    }
        //}
    }
}
