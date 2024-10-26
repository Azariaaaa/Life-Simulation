using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDisplayerUI : MonoBehaviour
{
    public Organism organism;
    public TextMeshProUGUI energyDisplayer;
    public Vector2 offset;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if(organism != null)
        {
            energyDisplayer.text = organism.energy.ToString();
            Vector3 worldPosition = organism.transform.position + (Vector3)offset;
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(worldPosition);
            energyDisplayer.transform.position = screenPosition;
        }
    }
}
