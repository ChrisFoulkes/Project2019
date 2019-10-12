using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterStats : MonoBehaviour
{

    GameObject statPanel;

    GameObject characterPanel;


    public Dictionary<StatName, Stat> statDict = new Dictionary<StatName, Stat>();

    public List<Stat> statList = new List<Stat>();

    public StatModifier increaseOne = new StatModifier(1f, StatName.Strength);

    private void Awake()
    {
        StartingStatData startingStat = Resources.Load<StartingStatData>("PlayerStats");


        //Panel References
        statPanel = GameObject.Find("CharacterUiPanels").transform.Find("CharacterStatPanel").gameObject;
        //characterPanel = GameObject.Find("CharacterUiPanels").transform.Find("CharacterInventoryPanel").gameObject;

        GenerateStats(startingStat);
       
       

    }




    // Start is called before the first frame update
    void Start()
    {
      
    }



    // Update is called once per frame
    void Update()
    {
       
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

        //resets stats-- warning!

        statList.Clear();

        foreach (BasicStatData statData in pstatlist.statList)
        {
            
            if (statDict.ContainsKey(statData.statName))
            {
                Debug.LogWarning("Player Duplicate stat implimentation warning!");
            }

            statDict.Add(statData.statName, new Stat(statData.startingvalue, statData.statName));
        }

    }
}
