using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class StatPanel : MonoBehaviour
{

    CharacterStats characterStats;



    GameObject statsGroup;
    TextMeshProUGUI[] statTexts;


    bool isdirty = true;


    public Dictionary<Stat, TextMeshProUGUI> statTextValues = new Dictionary<Stat, TextMeshProUGUI>();

    List<StatName> statnames = new List<StatName>();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Initalize() {

        characterStats = GameObject.Find("CharacterController").GetComponent<CharacterStats>();

        statsGroup = transform.Find("StatValuesGroup").gameObject;

        statTexts = statsGroup.GetComponentsInChildren<TextMeshProUGUI>();


       
       
        Debug.Log(characterStats.statDict.Count);
        statnames = characterStats.statDict.Keys.ToList();

        int counter = 0;
       

        foreach (TextMeshProUGUI texts in statTexts)
        {
            if (counter == statnames.Count)
            {
                Debug.Log("statsGroup contains a stat value that the character does not contain!");
                break;
            }

            statTextValues.Add(characterStats.statDict[statnames[counter]], texts);
            texts.text = characterStats.statDict[statnames[counter]].Value.ToString();
            counter++;
        }

        if (counter + 1 != statnames.Count)
        {
            Debug.Log("statsGroup missing a stat value that the character contains!");

        }

        EventManager.Current.RegisterListener<StatChange>(StatChange);

    }

    void OnEnable() {
        if (isdirty)
        {
            int counter = 0;
            foreach (TextMeshProUGUI texts in statTexts)
            {
                texts.text = characterStats.statDict[statnames[counter]].Value.ToString();
                counter++;
            }

            isdirty = false;
        }
    }

    void StatChange(StatChange statChange) {
        if (gameObject.activeSelf)
        {
            if (statTextValues[statChange.Stat] != null)
            {
                TextMeshProUGUI statText = statTextValues[statChange.Stat];
                statText.text = statChange.Stat.Value.ToString();
            }
        }
        else
        {
            isdirty = true;

        }
    }
}
