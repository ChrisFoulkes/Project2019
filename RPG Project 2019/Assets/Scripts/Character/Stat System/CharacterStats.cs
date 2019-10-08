using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterStats : MonoBehaviour
{


    GameObject statPanel;


    public Dictionary<StatName, Stat> statDict = new Dictionary<StatName, Stat>();

    public List<Stat> statList = new List<Stat>();

    public StatModifier increaseOne = new StatModifier(1f, StatName.Strength);

    private void Awake()
    {
      

        StartingStatData startingStat = Resources.Load<StartingStatData>("PlayerStats");

        GenerateStats(startingStat);
        

        //Temp Panel buttons remove soon
        statPanel = GameObject.Find("Canvas").transform.Find("tempStatPanel").gameObject;

    }




    // Start is called before the first frame update
    void Start()
    {
      
    }



    // Update is called once per frame
    void Update()
    {
        //needs to be removed 
        if (Input.GetKeyDown(KeyCode.C)) {
            if (statPanel.activeSelf)
            {
                statPanel.SetActive(false);
            }
            else
            {
                statPanel.SetActive(true);
            }
        }
        //---------------------------



        //Testing stat modifer buttons
        if (Input.GetKeyDown(KeyCode.F))
        {
            statDict[StatName.Strength].AddModifier(increaseOne);
            PopupText.Instance.GenerateText("Added +1 Strength Modifier!");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (statDict[StatName.Strength].RemoveModifier(increaseOne))
            {
                PopupText.Instance.GenerateText("Removed a +1 Strength Modifier!");
            }
        }
        //----------------------------------
    }

    void GenerateStats(StartingStatData pstatlist) {
        statList.Clear();
        foreach (BasicStatData statData in pstatlist.statList)
        {
            statList.Add(new Stat(statData.startingvalue, statData.statName));

            statDict.Add(statData.statName, statList[(statList.Count - 1)]);
        }

    }
}
