using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatsManager : MonoBehaviour
{
    public static GameStatsManager Instance { get; set; }

    public TextMeshProUGUI organismsAliveText;
    public TextMeshProUGUI organismsDeadText;
    public TextMeshProUGUI organismsBornText;
    public TextMeshProUGUI cellsKilledText;
    public TextMeshProUGUI foodEatenText;

    public int organismsAliveValue;
    public int organismsDeadValue;
    public int organismsBornValue;
    public int cellsKilledValue;
    public int foodEatenValue;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        StartCoroutine(UpdateUIEverySecond());
    }

    private void UpdateUI()
    {
        organismsAliveText.text = "Organisms alive : " + organismsAliveValue;
        organismsDeadText.text = "Organisms dead : " + organismsDeadValue;
        organismsBornText.text = "Organisms born : " + organismsBornValue;
        cellsKilledText.text = "Cells killed : " + cellsKilledValue;
        foodEatenText.text = "Foods eaten : " + foodEatenValue;
    }
    public void AddAliveOrganism()
    {
        organismsAliveValue++;
    }
    public void AddDeadOrganism()
    {
        organismsDeadValue++;
    }
    public void AddBornOrganism()
    {
        organismsBornValue++;
    }
    public void AddDeadCell()
    {
        cellsKilledValue++;
    }
    public void AddEatenFood()
    {
        foodEatenValue++;
    }
    private IEnumerator UpdateUIEverySecond()
    {
        while (true)
        {
            UpdateUI();
            yield return new WaitForSeconds(1f);
        }
    }
}
