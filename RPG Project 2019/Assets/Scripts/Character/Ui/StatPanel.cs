using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class StatPanel : MonoBehaviour
{
    public bool panelactive = false;
    CharacterStats characterStats;
    


    GameObject statsGroup;



    GameObject statTextPrefab;
    GameObject footerPanelPrefab;
    GameObject textContainer;

    GameObject headerPanel;


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
        statTextPrefab = (GameObject)Resources.Load("Prefabs/StatBackground");
        headerPanel = transform.Find("StatHeaderPanel").gameObject;
        textContainer = transform.Find("StatTextContainer").gameObject;
        footerPanelPrefab = (GameObject)Resources.Load("Prefabs/StatFooterPanel");
        foreach (StatName stat in characterStats.statDict.Keys) {
            GameObject go = Instantiate(statTextPrefab, textContainer.transform);
            TextMeshProUGUI textvalue = go.GetComponentInChildren<TextMeshProUGUI>();
            statTextValues.Add(characterStats.statDict[stat], textvalue);
            textvalue.text = characterStats.statDict[stat].statName + " : " + characterStats.statDict[stat].Value.ToString();
        }

        Instantiate(footerPanelPrefab, textContainer.transform);


        EventManager.Current.RegisterListener<StatChange>(StatChange);

    }

    public void EnablePanel() {
        headerPanel.SetActive(true);
        textContainer.SetActive(true);

        panelactive = true;

        if (isdirty)
        {
            
            foreach (Stat stat in statTextValues.Keys)
            {
                statTextValues[stat].text = stat.statName + " : " + stat.Value.ToString();
            }


            isdirty = false;
        }
    }

    public void DisablePanel() {
        panelactive = false;
        headerPanel.SetActive(false);
        textContainer.SetActive(false);
    }

    void StatChange(StatChange statChange) {
        if (panelactive)
        {
            if (statTextValues.ContainsKey(statChange.Stat))
            {
                if (statTextValues[statChange.Stat] != null)
                {

                    TextMeshProUGUI statText = statTextValues[statChange.Stat];
                    statText.text = statChange.Stat.statName + " : " + statChange.Stat.Value.ToString();

                } 
            }
        }
        else
        {
            isdirty = true;

        }
    }
}
