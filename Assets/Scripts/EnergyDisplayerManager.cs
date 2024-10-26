using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnergyDisplayerManager : MonoBehaviour
{
    public GameObject energyDisplayerPrefab;
    public List<Organism> organisms;
    public Canvas uiCanvas;

    private List<GameObject> energyDisplayers = new List<GameObject>();
    void Start()
    {
        GameManager.OnOrganismInitilized += OnOrganismInitialized;
        Organism.OnOrganismRemoved += OnOrganismRemoved;
    }

    private void CreateEnergyDisplayer(Organism organism)
    {
        GameObject energyDisplayerGO = Instantiate(energyDisplayerPrefab, uiCanvas.transform);
        EnergyDisplayerUI energyDisplayer = energyDisplayerGO.GetComponent<EnergyDisplayerUI>();
        energyDisplayer.organism = organism;
        energyDisplayer.offset = new Vector2(0,1);
        energyDisplayers.Add(energyDisplayerGO);
    }

    private void OnOrganismInitialized(Organism organism)
    {
        organisms.Add(organism);
        CreateEnergyDisplayer(organism);
    }

    private void OnOrganismRemoved(Organism organism)
    {
        List<GameObject> displayersToRemove = new List<GameObject>();

        foreach (GameObject energyDisplayer in energyDisplayers)
        {
            if (energyDisplayer.GetComponent<EnergyDisplayerUI>().organism == organism)
            {
                displayersToRemove.Add(energyDisplayer);
            }
        }

        foreach (GameObject displayer in displayersToRemove)
        {
            Destroy(displayer);
            energyDisplayers.Remove(displayer);
        }

        organisms.Remove(organism);
    }
}
